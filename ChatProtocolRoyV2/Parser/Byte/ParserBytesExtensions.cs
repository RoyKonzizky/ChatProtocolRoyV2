using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator;

namespace ChatProtocolRoyV2.Parser.Byte;

public class ParserBytesExtensions
{
    public static byte[] ExtractSyncAndTail(byte[] packetBytes)
    {
        if (packetBytes[0] != (byte)MessageEdge.Sync || packetBytes[^1] != (byte)MessageEdge.Tail)
            throw new ArgumentException("Unable to parse since Sync or Tail were corrupted.");
        byte[] arr = {};
        arr[0] = packetBytes[0];
        arr[1] = packetBytes[^1];
        return arr;
    }

    public uint ExtractChecksum(byte[] packetBytes)
    {
        var reversedPacketBytes = new byte[packetBytes.Length];
        Array.Copy(packetBytes, reversedPacketBytes, packetBytes.Length);
        Array.Reverse(reversedPacketBytes);

        var reversedChecksum = new byte[4];
        Array.Copy(reversedPacketBytes, 1, reversedChecksum, 0, 4);
        Array.Reverse(reversedChecksum);

        Generate generator = new Generate();
        
        var checksum = Generate.FromByteArray<uint>(reversedChecksum);
        return checksum;
    }


    public MessageBase ExtractData(byte[] packetBytes)
    {
        var arrMessageBase = new MessageBase[] { };
        Array.Copy(packetBytes, 1, arrMessageBase, 0, packetBytes.Length-5);
        var message = arrMessageBase[0];
        return message;
    }
}
//TODO look for a way to do this without the reverse