namespace ChatProtocolRoyV2.Parser.Byte.Message;

public interface IMessageParser<in TInput, out TOutput>
{
    TOutput Parse(TInput input);
}