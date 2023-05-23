using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Generator;
using ChatProtocolRoyV2.Generator.Byte;

namespace ChatProtocolRoyV2.Parser.Byte;

public class ParseBytes : IParseBytes
{
    public MessageBase Parser(byte[] packetBytes)
    {
        var generator = new Generate();
        var calculator = new ChecksumByteArrayCalculator();
        var parserExtender = new ParserBytesExtensions();

        var syncAndTailArray = parserExtender.ExtractSyncAndTail(packetBytes);
        var sync = syncAndTailArray[0];
        var tail = syncAndTailArray[1];
        if (!parserExtender.IsSyncAndTailEqual(sync, tail))
            throw new ArgumentException("Unable to parse since Sync and Tail cannot be determined.");

        var type = parserExtender.ExtractType(packetBytes);

        var checksumInPacket = parserExtender.ExtractChecksum(packetBytes);

        var dataOfPacket = parserExtender.ExtractData(packetBytes, type);
        var byteDataOfPacket = generator.ObjectToByteArray(dataOfPacket);
        var checksumFromData = calculator.CalculateChecksum(byteDataOfPacket);

        if (!parserExtender.IsChecksumEqual(checksumFromData, checksumInPacket))
            throw new ArgumentException("Unable to parse since data cannot be validated.");

        return dataOfPacket;
    }
}

//parser is the reverse process of the generator
