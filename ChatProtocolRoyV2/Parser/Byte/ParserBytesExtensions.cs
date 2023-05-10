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
        byte[] arr = {};
        arr[0] = packetBytes[0];
        arr[1] = packetBytes[^1];
        return arr;
    }
    public bool IsSyncAndTailEqual(byte sync, byte tail)
    {
        return sync==(int)MessageEdge.Sync && tail==(int)MessageEdge.Tail;
    }

    public uint ExtractChecksum(byte[] packetBytes)
    {
        var reversedPacketBytes = new byte[packetBytes.Length];
        Array.Copy(packetBytes, reversedPacketBytes, packetBytes.Length);
        Array.Reverse(reversedPacketBytes);

        var reversedChecksum = new byte[4];
        Array.Copy(reversedPacketBytes, 1, reversedChecksum, 0, 4);
        Array.Reverse(reversedChecksum);

        var generator = new Generate();
        
        var checksum = generator.FromByteArray<uint>(reversedChecksum);
        return checksum;
    }

    public bool IsChecksumEqual(uint checksumFromData, uint checksumInPacket)
    {
        return checksumFromData == checksumInPacket;
    }
    
    public MessageBase ExtractData(byte[] packetBytes)
    {
        var arrMessageBase = Array.Empty<MessageBase>();
        Array.Copy(packetBytes, 1, arrMessageBase, 0, packetBytes.Length-5);
        var message = arrMessageBase[0];
        return message;
    }
}
//TODO look for a way to do this without the reverse-can be done by parsing the data before the checksum using length of array copy