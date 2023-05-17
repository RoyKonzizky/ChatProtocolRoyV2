namespace ChatProtocolRoyV2.Builder.Message.Types.Text;

public interface ITextMessageBuilder : IMessageBuilder
{
    IMessageBuilder WithText(string text);
}