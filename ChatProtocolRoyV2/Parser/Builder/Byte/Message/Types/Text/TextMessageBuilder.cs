using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Guid;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.Text;

public class TextMessageBuilder : IMessageBuilder<IEnumerable<byte>>
{
    //holds all the builders of its properties
    //build method - activating all the small builders and returning TextMessage
    public MessageBase Build(IEnumerable<byte> input)
    {
        var guidBuilder = new GuidBuilder();
        var dataBuilder = new DataBuilder();

        var enumerable = input as byte[] ?? input.ToArray();
        var textMessage = new TextMessage(guidBuilder.Build(enumerable), dataBuilder.Build(enumerable));

        return textMessage;
    }
}