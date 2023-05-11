using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Generator;
using ChatProtocolRoyV2.Generator.ChecksumCalculation.Byte;

namespace ChatProtocolRoyV2.Parser.Byte;

public class ParseBytes : IParseBytes
{
    public MessageBase Parser(byte[] packetBytes)
    {
        MessageBase message = null!;
        var generator = new Generate();
        var calculator = new ChecksumByteArrayCalculator();
        var parserExtender = new ParserBytesExtensions();

        var syncAndTailArray = parserExtender.ExtractSyncAndTail(packetBytes);
        var sync = syncAndTailArray[0];
        var tail = syncAndTailArray[1];
        if (!parserExtender.IsSyncAndTailEqual(sync, tail))
            throw new ArgumentException("Unable to parse since Sync and Tail cannot be determined.");
        var checksumInPacket = parserExtender.ExtractChecksum(packetBytes);

        var dataOfPacket = parserExtender.ExtractData(packetBytes);
        var byteDataOfPacket = generator.ObjectToByteArray(dataOfPacket);
        var checksumFromData = calculator.CalculateChecksum(byteDataOfPacket);

        if (parserExtender.IsChecksumEqual(checksumFromData, checksumInPacket)) return message;
        throw new ArgumentException("Unable to parse since data cannot be validated.");
    }
}
//parser is the reverse process of the generator