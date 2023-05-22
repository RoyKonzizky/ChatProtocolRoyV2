using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Generator;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.FileName;

public class FileNameBuilder : IFileNameBuilder
{
    public string Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var nameBytes = Array.Empty<byte>();
        Array.Copy(inputBytes, Indexes.FILE_NAME_INDEX, nameBytes, 0, Lengths.FILE_NAME_LENGTH);
        var generator = new Generate();
        var nameFile = generator.FromByteArray<string>(nameBytes);
        return nameFile;
    }
}