using ChatProtocolRoyV2.DataModule;

namespace ChatProtocolRoyV2.ParserModule;

public interface IParsing<in TInput>
{
    MessageBase Parser(TInput input);
}