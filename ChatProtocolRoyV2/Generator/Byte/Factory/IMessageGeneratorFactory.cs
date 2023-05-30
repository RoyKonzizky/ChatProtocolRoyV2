using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Generator.Byte.Message;

namespace ChatProtocolRoyV2.Generator.Byte.Factory;

public interface IMessageGeneratorFactory
{
    IMessageGenerator CreateMessageGenerator(MessageBase messageBase);
}    

//TODO since it takes singletons, it's more akin to a Provider, it accepts all types of generators
