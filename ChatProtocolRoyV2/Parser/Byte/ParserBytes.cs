using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Parser.Builder.Byte.Director;

namespace ChatProtocolRoyV2.Parser.Byte;

public class ParseBytes : IParseBytes
{
    public MessageBase Parser(IEnumerable<byte> packetBytes)
    {
        var director = new Director();
        IEnumerable<byte> enumerable = packetBytes as byte[] ?? packetBytes.ToArray();
        var packetMessageBase = director.Build(enumerable);
        return packetMessageBase;
    }
}

//TODO read about TryParse, yield 
//TODO parser for each main type, read about Provider