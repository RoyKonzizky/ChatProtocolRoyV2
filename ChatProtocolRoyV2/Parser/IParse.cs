using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Parser;

public interface IParse<in TInput>
{
    MessageBase Parser(TInput input);
}