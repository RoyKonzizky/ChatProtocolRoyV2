using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.DateOnly;

public class DateOnlyBuilder : IDateOnlyBuilder
{
    private readonly IHelpBytes _helper;
    private readonly ILengthBuilder _lengthBuilder;

    public DateOnlyBuilder(ILengthBuilder lengthBuilder, IHelpBytes helper)
    {
        _lengthBuilder = lengthBuilder;
        _helper = helper;
    }

    public System.DateOnly Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var dateOnlyBytes = Array.Empty<byte>();
        Array.Copy(inputBytes,
            Indexes.LENGTH_OF_DATA_INDEX + 1 + _lengthBuilder.Build(inputBytes) + Lengths.FILE_TYPE_LENGTH,
            dateOnlyBytes, 0, Lengths.DATE_ONLY_LENGTH);
        var dateOnly = _helper.FromByteArray<System.DateOnly>(dateOnlyBytes);
        return dateOnly;
    }
}