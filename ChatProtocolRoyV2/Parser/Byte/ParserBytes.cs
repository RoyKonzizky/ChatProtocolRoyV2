using System.Collections;
using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Generator.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Director;

namespace ChatProtocolRoyV2.Parser.Byte;

public class ParseBytes : IParseBytes
{
    public ArrayList Parser(byte[] packetBytes)
    {
        var director = new Director();
        var packetData = director.Build(packetBytes);
        var calc = new ChecksumByteArrayCalculator();
        var generator = new Generate();
        if ((uint)packetData[3]! == calc.CalculateChecksum(generator.ObjectToByteArray(packetData[4])))
        {
            return packetData;
        }

        throw new Exception("checksums aren't equal, data has been corrupted");
    }
}

//parser is the reverse process of the generator
//TODO read about down/up-casting and TryParse, MessageBase messageBase = new FileMessage(),byte.TryParse()