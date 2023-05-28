namespace ChatProtocolRoyV2.Parser.Builder;

public interface IBuilder<in TInput, out TOutput>
{
    TOutput Build(TInput input);
}