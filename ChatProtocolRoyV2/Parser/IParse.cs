using System.Collections;
using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Parser;

public interface IParse<in TInput>
{
    ArrayList Parser(TInput input);
}