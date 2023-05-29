using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Type;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;

public class LengthBuilder : ILengthBuilder
{
    public int Build(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();
        var typeBuilder = new TypeBuilder();
        var type = typeBuilder.Build(enumerable);
        var inputBytes = enumerable.ToArray();
        var nameBytes = Array.Empty<byte>();
        var helper = new HelpBytes();
        var len = 0;
        switch (type)
        {
            case MessageType.TextMessage:
                Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX, nameBytes, 0, Lengths.LENGTH_OF_DATA_LENGTH);
                len = helper.FromByteArray<int>(nameBytes);
                return len;

            case MessageType.FileMessage:
                Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX, nameBytes, 0, Lengths.LENGTH_OF_DATA_LENGTH);
                len = helper.FromByteArray<int>(nameBytes);
                return len;

            default:
                throw new Exception("no matching type");
        }
    }
}