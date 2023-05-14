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
        byte[]checksumArr = Array.Empty<byte>();
        Array.Copy(packetBytes, packetBytes.Length-5, checksumArr, 0, 4);
        var generator = new Generate();
        var checksum = generator.FromByteArray<uint>(checksumArr);
        return checksum;
    }

    public bool IsChecksumEqual(uint checksumFromData, uint checksumInPacket)
    {
        return checksumFromData == checksumInPacket;
    }

    public MessageBase ExtractData(byte[] packetBytes)
    {
        var generator = new Generate();
        var arrMessageBase = new byte[packetBytes.Length - 5];
        Array.Copy(packetBytes, 1, arrMessageBase, 0, packetBytes.Length - 5);
        var deserializeMessageBase = generator.FromByteArray<MessageBase>(arrMessageBase);
        return deserializeMessageBase;
    }
}
