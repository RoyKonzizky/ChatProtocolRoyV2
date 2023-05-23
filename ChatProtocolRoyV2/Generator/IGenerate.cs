namespace ChatProtocolRoyV2.Generator;

public interface IGenerate<in TInput,out TOutput>
{
    TOutput GeneratePacket(TInput input);
}