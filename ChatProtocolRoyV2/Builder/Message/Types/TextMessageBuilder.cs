using ChatProtocolRoyV2.Builder.Message;
using ChatProtocolRoyV2.Builder.Properties;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Builder.Message.Types;

public class TextMessageBuilder : IMessageBuilder
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

    public IMessageBuilder WithFile(string fileName, string fileContent, DateOnly dateOnly, FileTypes fileType)
    {
        throw new NotImplementedException();
    }

    public MessageBase Build(object input)
    {
        var textMessage = new TextMessage(_guid, _text);

        _guid = default;
        _text = default;

        return textMessage;
    }

}
//TODO for file builder too, change it from default and from object input to something else
