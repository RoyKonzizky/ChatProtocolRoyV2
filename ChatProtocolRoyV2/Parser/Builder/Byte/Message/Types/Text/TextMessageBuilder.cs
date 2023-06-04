using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Guid;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.Text;

public class TextMessageBuilder : ITextMessageBuilder
{
    private readonly IDataBuilder _dataBuilder;
    private readonly IGuidBuilder _guidBuilder;

    //holds all the builders of its properties
    //build method - activating all the small builders and returning TextMessage
    public TextMessageBuilder(IGuidBuilder guidBuilder, IDataBuilder dataBuilder)
    {
        _guidBuilder = guidBuilder;
        _dataBuilder = dataBuilder;
    }

    public TextMessage Build(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();
        var textMessage = new TextMessage(_guidBuilder.Build(enumerable), _dataBuilder.Build(enumerable));

        return textMessage;
    }
}