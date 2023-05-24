using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.File;
using ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.Text;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Checksum;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Guid;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Sync;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Tail;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Type;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Director;

public class Director : IDirector
{
    public MessageBase Build(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();
        var sync = new SyncBuilder().Build(enumerable);
        var guid = new GuidBuilder().Build(enumerable);
        var type = new TypeBuilder().Build(enumerable);
        var checksum = new ChecksumBuilder().Build(enumerable);
        var tail = new TailBuilder().Build(enumerable);
        var data = new DataBuilder().Build(enumerable);
        var lenData = new LengthBuilder().Build(enumerable);
        
        var textMessageBuilder = new TextMessageBuilder();
        var fileMessageBuilder = new FileMessageBuilder();

        var messageBase = type switch
        {
            MessageType.TextMessage => textMessageBuilder.Build(enumerable),
            MessageType.FileMessage => fileMessageBuilder.Build(enumerable),
            _ => throw new Exception("invalid type")
        };
        return messageBase;
    }
}