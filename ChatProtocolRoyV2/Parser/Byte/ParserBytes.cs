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
        ParserBytesExtensions parserExtender = new ParserBytesExtensions();
        
        byte[] syncAndTailArray = ParserBytesExtensions.ExtractSyncAndTail(packetBytes);
        byte sync = syncAndTailArray[0];
        byte tail = syncAndTailArray[1];
        
        uint checksumInPacket = parserExtender.ExtractChecksum(packetBytes);
        
        MessageBase dataOfPacket = parserExtender.ExtractData(packetBytes);
        IEnumerable<byte> byteDataOfPacket = Generate.ObjectToByteArray(dataOfPacket); 
        uint checksumFromData = calculator.CalculateChecksum(byteDataOfPacket);
        if (checksumFromData != checksumInPacket)
        {
            throw new ArgumentException("Unable to parse since data or checksum were corrupted.");
        }
        
        return message;
    }
    
}
//since the data already contains the guid and the type its pointless for them to be in the packet
//parser is the reverse process of the generator