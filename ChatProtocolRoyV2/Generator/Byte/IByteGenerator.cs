using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Generator.Byte;

public interface IByteGenerator<in T> : IGenerator<T, IEnumerable<byte>>
{
}