namespace ChatProtocolRoyV2.Parser.Builder.Byte;

public interface IBuilder<in TInput, out TOutput>
{
    TOutput Build(TInput input);
}