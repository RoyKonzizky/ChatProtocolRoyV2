using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Generator.Byte.Message;

public interface IMessageGenerator : IByteGenerator<MessageBase, IEnumerable<byte>>
{
}
//TODO inherit from IByteGenerator as its above it in the hierarchy and has the same input/output