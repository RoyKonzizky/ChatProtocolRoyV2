using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Director;

public interface IDirector : IBuilder<IEnumerable<byte>, MessageBase>
{
}