using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Generator;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.DateOnly;

public class DateOnlyBuilder : IDateOnlyBuilder
{
    public System.DateOnly Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var dateOnlyBytes = Array.Empty<byte>();
        Array.Copy(inputBytes, Indexes.DATE_ONLY_INDEX, dateOnlyBytes, 0, Lengths.DATE_ONLY_LENGTH);
        var generator = new Generate();
        var dateOnly = generator.FromByteArray<System.DateOnly>(dateOnlyBytes);
        return dateOnly;
    }
}