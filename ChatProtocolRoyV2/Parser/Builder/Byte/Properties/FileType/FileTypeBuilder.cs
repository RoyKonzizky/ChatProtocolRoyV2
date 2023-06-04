using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.FileType;

public class FileTypeBuilder : IFileTypeBuilder
{
    private readonly IHelpBytes _helper;
    private readonly ILengthBuilder _lengthBuilder;

    public FileTypeBuilder(ILengthBuilder lengthBuilder, IHelpBytes helper)
    {
        _lengthBuilder = lengthBuilder;
        _helper = helper;
    }

    public FileTypes Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var fileTypesBytes = Array.Empty<byte>();
        Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX + 1 + _lengthBuilder.Build(inputBytes), fileTypesBytes, 0,
            Lengths.FILE_TYPE_LENGTH);
        var typeFile = _helper.FromByteArray<FileTypes>(fileTypesBytes);
        return typeFile;
    }
}