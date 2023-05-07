using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator;

namespace ChatProtocolRoyV2.Parser.Types
{
    public class Parse : IParseBytes
    {
        public Packet<MessageBase> Parser(byte[] packetBytes)
        {
            using (var stream = new MemoryStream(packetBytes))
            {
                var formatter = new BinaryFormatter();
                var packet = (Packet<MessageBase>)formatter.Deserialize(stream);

                MessageType messageType = GetMessageFromPacket(packet);

                if (packet.Data is TextMessage textMessage)
                {
                    return new Packet<MessageBase>(packet.Id, messageType, new TextMessage(packet.Id, messageType, textMessage.Data), packet.Checksum, packet.Sync, packet.Tail);
                }
                else if (packet.Data is FileMessage fileMessage)
                {
                    return new Packet<MessageBase>(packet.Id, messageType, new FileMessage(packet.Id, messageType, fileMessage.DateOnly, fileMessage.FileName, fileMessage.DataInFile, fileMessage.FileType), packet.Checksum, packet.Sync, packet.Tail);
                }
                else if (packet.Data is Audio)
                {
                    var audioBuilder = new MessageBuilder(messageType, packet.Id);
                    MessageBase audioMessage = audioBuilder.Build();
                    return new Packet<MessageBase>(packet.Id, messageType, audioMessage, packet.Checksum, packet.Sync, packet.Tail);
                }
                else if (packet.Data is Image)
                {
                    var imageBuilder = new MessageBuilder(messageType, packet.Id);
                    MessageBase imageMessage = imageBuilder.Build();
                    return new Packet<MessageBase>(packet.Id, messageType, imageMessage, packet.Checksum, packet.Sync, packet.Tail);
                }
                else
                {
                    throw new ArgumentException("Invalid data type for message.");
                }
            }
        }

        private static MessageType GetMessageFromPacket(Packet<MessageBase> packet)
        {
            if (packet.Data is TextMessage)
                return MessageType.TextMessage;
            if (packet.Data is FileMessage)
                return MessageType.FileMessage;
            if (packet.Data is Audio)
                return MessageType.Audio;
            if (packet.Data is Image)
                return MessageType.Image;
            throw new ArgumentException("Invalid data type for message.");
        }
    }
}
