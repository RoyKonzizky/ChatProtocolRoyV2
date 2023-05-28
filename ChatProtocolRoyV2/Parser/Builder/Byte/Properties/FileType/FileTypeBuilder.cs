using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator.Byte;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.FileType;

public class FileTypeBuilder : IFileTypeBuilder
{
    public FileTypes Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var fileTypesBytes = Array.Empty<byte>();
        Array.Copy(inputBytes, Indexes.FILE_TYPE_INDEX, fileTypesBytes, 0, Lengths.FILE_TYPE_LENGTH);
        var generator = new Generate();
        var typeFile = generator.FromByteArray<FileTypes>(fileTypesBytes);
        return typeFile;
    }
}