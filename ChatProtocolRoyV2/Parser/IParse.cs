using System.Collections;
using ChatProtocolRoyV2.Generator;

namespace ChatProtocolRoyV2.Parser;

public interface IParse<in TInput>
{
    Packet Parser(TInput input);
}
//TODO MessageBase instead of Packet