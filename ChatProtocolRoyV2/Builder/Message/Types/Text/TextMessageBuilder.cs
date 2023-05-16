using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;

namespace ChatProtocolRoyV2.Builder.Message.Types.Text;

public class TextMessageBuilder : ITextMessageBuilder
{
    private Guid _guid;
    private string _text = null!;

    public IMessageBuilder WithGuid(Guid guid)
    {
        _guid = guid;
        return this;
    }

    public IMessageBuilder WithText(string text)
    {
        _text = text;
        return this;
    }

    public MessageBase Build(object input)
    {
        var textMessage = new TextMessage(_guid, _text);

        _guid = default;
        _text = "";

        return textMessage;
    }

}
//TODO for file builder too, change it from default and from object input to something else
