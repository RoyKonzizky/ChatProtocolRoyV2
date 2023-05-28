using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Generator.Byte;

//todo use MessageBase and creational design patterns into IEnumerable<byte> instead of arraylist
public interface IByteGenerator : IGenerator<MessageBase, IEnumerable<byte>>
{
}