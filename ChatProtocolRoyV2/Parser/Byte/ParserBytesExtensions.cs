using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator;

namespace ChatProtocolRoyV2.Parser.Byte;

public class ParserBytesExtensions
{
    public byte[] ExtractSyncAndTail(byte[] packetBytes)
    {
        if (packetBytes[0] != (byte)MessageEdge.Sync || packetBytes[^1] != (byte)MessageEdge.Tail)
            throw new ArgumentException("Unable to parse since Sync or Tail were corrupted.");
        var arr = Array.Empty<byte>();
        arr[0] = packetBytes[0];
        arr[1] = packetBytes[^1];
        return arr;
    }

    public bool IsSyncAndTailEqual(byte sync, byte tail)
    {
        return sync == (int)MessageEdge.Sync && tail == (int)MessageEdge.Tail;
    }

    public uint ExtractChecksum(byte[] packetBytes)
    {
        var checksumArr = Array.Empty<byte>();
        Array.Copy(packetBytes, packetBytes.Length-5, checksumArr, 0, 4);
        var generator = new Generate();
        var checksum = generator.FromByteArray<uint>(checksumArr);
        return checksum;
    }

    public bool IsChecksumEqual(uint checksumFromData, uint checksumInPacket)
    {
        return checksumFromData == checksumInPacket;
    }
    
    public object ExtractType(byte[] packetBytes)
    {
        var generator = new Generate();
        var typeBytes = Array.Empty<byte>();
        Array.Copy(packetBytes, 1, typeBytes, 0, 4);
        var type = generator.FromByteArray<object>(typeBytes);
        return type;
    }

    public MessageBase ExtractData(byte[] packetBytes, object type)
    {
        var generator = new Generate();
        var arrMessageBase = new byte[packetBytes.Length - 9];
        Array.Copy(packetBytes, 5, arrMessageBase, 0, packetBytes.Length - 9);
    
        switch (type)
        {
            case MessageType.TextMessage:
                var deserializedTextMessage = generator.FromByteArray<MessageBase>(arrMessageBase);
                return deserializedTextMessage;

            case MessageType.FileMessage:
                var deserializedFileMessage = generator.FromByteArray<MessageBase>(arrMessageBase);
                return deserializedFileMessage;
        
            case FileTypes.Audio:
                var deserializedAudio = generator.FromByteArray<MessageBase>(arrMessageBase);
                return deserializedAudio;
        
            case FileTypes.Image:
                var deserializedImage = generator.FromByteArray<MessageBase>(arrMessageBase);
                return deserializedImage;

            default:
                throw new Exception("No matching message could be created for this type");
        }
    }
}

//TODO read about down/up-casting and TryParse, MessageBase messageBase = new FileMessage(),byte.TryParse()
//TODO since type was added need to check and change the other extraction methods

