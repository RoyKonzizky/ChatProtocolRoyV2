using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Helper;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.DateOnly;

public class DateOnlyBuilder : IDateOnlyBuilder
{
    public System.DateOnly Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var dateOnlyBytes = Array.Empty<byte>();
        var lengthBuilder = new LengthBuilder();
        Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX + 1 +  lengthBuilder.Build(inputBytes) + Lengths.FILE_TYPE_LENGTH, dateOnlyBytes, 0, Lengths.DATE_ONLY_LENGTH);
        var helper = new Help();
        var dateOnly = helper.FromByteArray<System.DateOnly>(dateOnlyBytes);
        return dateOnly;
    }
}