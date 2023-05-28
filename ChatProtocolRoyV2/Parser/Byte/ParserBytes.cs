using System.Collections;
using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Parser.Builder.Byte.Director;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Checksum;

namespace ChatProtocolRoyV2.Parser.Byte;

public class ParseBytes : IParseBytes
{
    public MessageBase Parser(byte[] packetBytes)
    {
        var director = new Director();
        var packetMessageBase = director.Build(packetBytes);
        var calc = new ChecksumByteArrayCalculator();
        var generator = new Generator.Byte.ByteGenerator();
        var checksumBuilder = new ChecksumBuilder();
        switch (packetMessageBase.Type)
        {
            case MessageType.FileMessage:
                var fileMessage = (FileMessage)packetMessageBase;
                if (checksumBuilder.Build(packetBytes) == calc.CalculateChecksum(generator.ObjectToByteArray(fileMessage.Data)))
                {
                    return packetMessageBase;
                }
                break;

            case MessageType.TextMessage:
                var textMessage = (TextMessage)packetMessageBase;
                if (checksumBuilder.Build(packetBytes) == calc.CalculateChecksum(generator.ObjectToByteArray(textMessage.Data)))
                {
                    return packetMessageBase;
                }
                break;
        }
        throw new Exception("checksums aren't equal, data has been corrupted");
    }
}

//parser is the reverse process of the generator
//TODO read about down/up-casting and TryParse, MessageBase messageBase = new FileMessage(),byte.TryParse()