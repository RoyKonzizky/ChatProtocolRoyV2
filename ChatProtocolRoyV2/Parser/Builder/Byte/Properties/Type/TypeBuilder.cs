using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator;
using ChatProtocolRoyV2.Generator.Byte;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Type;

public class TypeBuilder : ITypeBuilder
{
    public MessageType Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var typeBytes = Array.Empty<byte>();
        Array.Copy(inputBytes, Indexes.TYPE_INDEX, typeBytes, 0, 4);
        var generator = new Generate();
        var type = generator.FromByteArray<MessageType>(typeBytes);
        return type;
    }
}