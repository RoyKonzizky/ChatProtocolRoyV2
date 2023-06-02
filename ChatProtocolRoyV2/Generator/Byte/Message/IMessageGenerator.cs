using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Generator.Byte.Message;

public interface IMessageGenerator : IGenerator<MessageBase,IEnumerable<byte>>
{
}
//TODO should inherit from IGenerator - done