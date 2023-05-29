using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Generator;

public interface IByteGenerator
{
    IEnumerable<byte> Generate(MessageBase messageBase);
}