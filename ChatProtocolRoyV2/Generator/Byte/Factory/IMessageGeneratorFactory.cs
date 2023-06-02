using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Generator.Byte.Message;

namespace ChatProtocolRoyV2.Generator.Byte.Factory;

public interface IMessageGeneratorFactory : IGenerator<MessageBase, IMessageGenerator>
{
}    

