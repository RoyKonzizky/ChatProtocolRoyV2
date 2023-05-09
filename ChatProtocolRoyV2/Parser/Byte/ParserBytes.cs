using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator;
using ChatProtocolRoyV2.Generator.ChecksumCalculation.Types;

namespace ChatProtocolRoyV2.Parser.Byte;

public class ParseBytes : IParseBytes
{
    public MessageBase Parser(byte[] packetBytes)
    {
        MessageBase message = null!;
        Generate generator = new Generate();
        ChecksumByteArrayCalculator calculator = new ChecksumByteArrayCalculator();
        
        byte[] syncAndTailArray = ExtractSyncAndTail(packetBytes);
        byte sync = syncAndTailArray[0];
        byte tail = syncAndTailArray[1];
        
        uint checksumInPacket = ExtractChecksum(packetBytes);
        
        MessageBase dataOfPacket = ExtractData(packetBytes);
        IEnumerable<byte> byteDataOfPacket = Generate.ObjectToByteArray(dataOfPacket); 
        uint checksumFromData = calculator.CalculateChecksum(byteDataOfPacket);
        if (checksumFromData != checksumInPacket)
        {
            throw new ArgumentException("Unable to parse since data or checksum were corrupted.");
        }
        
        

        return message;
    }
    
    
    private static byte[] ExtractSyncAndTail(byte[] packetBytes)
    {
        if (packetBytes[0] == (byte)MessageEdge.Sync && packetBytes[^1] == (byte)MessageEdge.Tail)
        {
            byte[] arr = {};
            arr[0] = packetBytes[0];
            arr[1] = packetBytes[^1];
            return arr;
        }
        throw new ArgumentException("Unable to parse since Sync or Tail were corrupted.");
    }

    private static uint ExtractChecksum(byte[] packetBytes)
    {
        byte[] reversedPacketBytes = new byte[packetBytes.Length];
        Array.Copy(packetBytes, reversedPacketBytes, packetBytes.Length);
        Array.Reverse(reversedPacketBytes);

        byte[] reversedChecksum = new byte[4];
        Array.Copy(reversedPacketBytes, 1, reversedChecksum, 0, 4);
        Array.Reverse(reversedChecksum);

        Generate generator = new Generate();
        
        uint checksum = Generate.FromByteArray<uint>(reversedChecksum);
        return checksum;
    }
    
    
    private static MessageBase ExtractData(byte[] packetBytes)
    {
        MessageBase message;
        
        return message;
    }
    
}
//TODO look for a way to do this without the reverse
//TODO finish the ExtractData method
//since the data already contains the guid and the type its pointless for them to be in the packet
//parser is the reverse process of the generator