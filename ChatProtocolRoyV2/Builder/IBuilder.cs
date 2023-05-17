namespace ChatProtocolRoyV2.Builder;

public interface IBuilder<in TInput, out TOutput>
{
    TOutput Build(TInput input);
}

//Make IBuilder for each attribute of a packet
//TODO find what is actually supposed to be written there