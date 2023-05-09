using System.Collections;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Generator;

namespace ChatProtocolRoyV2.Parser;

public interface IParse<in TInput>
{
    MessageBase Parser(TInput input);
}