using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.FileName;

public class FileNameBuilder : IFileNameBuilder
{
    private readonly IHelpBytes _helper;
    private readonly ILengthBuilder _lengthBuilder;

    public FileNameBuilder(ILengthBuilder lengthBuilder, IHelpBytes helper)
    {
        _lengthBuilder = lengthBuilder;
        _helper = helper;
    }

    public string Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var nameBytes = Array.Empty<byte>();
        Array.Copy(inputBytes,
            Indexes.LENGTH_OF_DATA_INDEX + 1 + _lengthBuilder.Build(inputBytes) + Lengths.FILE_TYPE_LENGTH +
            Lengths.DATE_ONLY_LENGTH, nameBytes, 0, Lengths.FILE_NAME_LENGTH);
        var nameFile = _helper.FromByteArray<string>(nameBytes);
        return nameFile;
    }
}