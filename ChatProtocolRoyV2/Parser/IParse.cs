using System.Collections;

namespace ChatProtocolRoyV2.Parser;

public interface IParse<in TInput>
{
    ArrayList Parser(TInput input);
}