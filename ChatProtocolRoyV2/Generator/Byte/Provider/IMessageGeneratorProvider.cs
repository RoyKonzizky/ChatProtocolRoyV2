using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Generator.Byte.Message;

namespace ChatProtocolRoyV2.Generator.Byte.Provider;

public interface IMessageGeneratorProvider : IGenerator<MessageBase, IMessageGenerator>
{
}    

