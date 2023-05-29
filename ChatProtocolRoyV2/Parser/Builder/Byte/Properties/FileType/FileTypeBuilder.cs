using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;


namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.FileType;

public class FileTypeBuilder : IFileTypeBuilder
{
    public FileTypes Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var fileTypesBytes = Array.Empty<byte>();
        var lengthBuilder = new LengthBuilder();
        Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX + 1 +  lengthBuilder.Build(inputBytes), fileTypesBytes, 0, Lengths.FILE_TYPE_LENGTH);
        var helper = new Help();
        var typeFile = helper.FromByteArray<FileTypes>(fileTypesBytes);
        return typeFile;
    }
}