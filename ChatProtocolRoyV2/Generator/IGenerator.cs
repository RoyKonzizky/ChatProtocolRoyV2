namespace ChatProtocolRoyV2.Generator;

public interface IGenerator<in TInput, out TOutput>
{
    TOutput Generate(TInput input);
}