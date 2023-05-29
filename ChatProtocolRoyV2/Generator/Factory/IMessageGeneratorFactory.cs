using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Generator.Message;

namespace ChatProtocolRoyV2.Generator.Factory;

public interface IMessageGeneratorFactory
{
    IMessageGenerator CreateMessageGenerator(MessageBase messageBase);
}