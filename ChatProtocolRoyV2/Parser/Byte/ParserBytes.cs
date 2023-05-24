using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Parser.Builder.Byte.Director;

namespace ChatProtocolRoyV2.Parser.Byte;

public class ParseBytes : IParseBytes
{
    public MessageBase Parser(byte[] packetBytes)
    {
        var director = new Director();
        var data = director.Build(packetBytes);
        return data;
    }
}

//parser is the reverse process of the generator
//TODO read about down/up-casting and TryParse, MessageBase messageBase = new FileMessage(),byte.TryParse()
