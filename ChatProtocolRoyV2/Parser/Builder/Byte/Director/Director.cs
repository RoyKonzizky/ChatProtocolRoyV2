using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.File;
using ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.Text;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Checksum;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Type;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Director;

public class Director : IDirector
{
    public MessageBase Build(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();
        var type = new TypeBuilder().Build(enumerable);
        var checksum = new ChecksumBuilder().Build(enumerable);
        var data = new DataBuilder().Build(enumerable);

        var textMessageBuilder = new TextMessageBuilder();
        var fileMessageBuilder = new FileMessageBuilder();

        var calculator = new ChecksumByteArrayCalculator();
        var generator = new ByteGenerator();
        var checksumFromMessageData = calculator.CalculateChecksum(generator.ObjectToByteArray(data));


        if (checksum != checksumFromMessageData)
            throw new Exception("Checksums do not match, message has been corrupted");
        var messageBase = type switch
        {
            MessageType.TextMessage => textMessageBuilder.Build(enumerable),
            MessageType.FileMessage => fileMessageBuilder.Build(enumerable),
            _ => throw new Exception("Invalid type")
        };
        return messageBase;

    }
}