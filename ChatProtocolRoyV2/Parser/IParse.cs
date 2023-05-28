using System.Collections;

namespace ChatProtocolRoyV2.Parser;

public interface IParse<in TInput>
{
    //todo return MessageBase instead of arraylist, the builder should help
    ArrayList Parser(TInput input);
}