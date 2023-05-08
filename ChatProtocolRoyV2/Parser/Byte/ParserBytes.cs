using System.Text.Json;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Data.Types.Files;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator;

namespace ChatProtocolRoyV2.Parser.Byte;

public class ParseBytes : IParseBytes
{
    public Packet Parser(byte[] packetBytes)
    {
        using var stream = new MemoryStream(packetBytes);
        var packet = JsonSerializer.Deserialize<Packet>(stream);

        if (packet == null) throw new ArgumentException("Invalid data type for message.");
        MessageType messageType = GetMessageFromPacket(packet);

        switch (packet.Data)
        {
            case TextMessage textMessage:
            {
                var textBuilder = new MessageBuilder()
                    .WithType(messageType)
                    .WithGuid(packet.Id)
                    .WithText(textMessage.Data);

                MessageBase parsedMessage = textBuilder.Build();
                return new Packet(packet.Sync, packet.Id, messageType, parsedMessage, packet.Checksum, packet.Tail);
            }
            case FileMessage fileMessage:
            {
                var fileBuilder = new MessageBuilder()
                    .WithType(messageType)
                    .WithGuid(packet.Id)
                    .WithFile(fileMessage.FileName, fileMessage.DataInFile, fileMessage.DateOnly, fileMessage.FileType);

                MessageBase parsedMessage = fileBuilder.Build();
                return new Packet(packet.Sync, packet.Id, messageType, parsedMessage, packet.Checksum, packet.Tail);
            }
            case Audio:
            {
                var audioBuilder = new MessageBuilder()
                    .WithType(messageType)
                    .WithGuid(packet.Id);

                MessageBase audioMessage = audioBuilder.Build();
                return new Packet(packet.Sync, packet.Id, messageType, audioMessage, packet.Checksum, packet.Tail);
            }
            case Image:
            {
                var imageBuilder = new MessageBuilder()
                    .WithType(messageType)
                    .WithGuid(packet.Id);

                MessageBase imageMessage = imageBuilder.Build();
                return new Packet(packet.Sync, packet.Id, messageType, imageMessage, packet.Checksum, packet.Tail);
            }
            default:
                throw new ArgumentException("Invalid data type for message.");
        }
    }

    private static MessageType GetMessageFromPacket(Packet packet)
    {
        return packet.Data switch
        {
            TextMessage => MessageType.TextMessage,
            FileMessage => MessageType.FileMessage,
            Audio => MessageType.Audio,
            Image => MessageType.Image,
            _ => throw new ArgumentException("Invalid data type for message.")
        };
    }
}