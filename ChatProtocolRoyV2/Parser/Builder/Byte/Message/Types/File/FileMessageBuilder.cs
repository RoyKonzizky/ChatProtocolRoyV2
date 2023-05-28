using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types.Files;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.DateOnly;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.FileName;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.FileType;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Guid;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.File;

public class FileMessageBuilder : IMessageBuilder<IEnumerable<byte>>
{
    public MessageBase Build(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();

        var guidBuilder = new GuidBuilder();
        var dataBuilder = new DataBuilder();
        var fileTypeBuilder = new FileTypeBuilder();
        var fileNameBuilder = new FileNameBuilder();
        var dateOnlyBuilder = new DateOnlyBuilder();

        MessageBase fileMessage = fileTypeBuilder.Build(enumerable) switch
        {
            FileTypes.Image => new Image(guidBuilder.Build(enumerable), dataBuilder.Build(enumerable), dateOnlyBuilder.Build(enumerable), fileNameBuilder.Build(enumerable), FileTypes.Image),
            FileTypes.Audio => new Audio(guidBuilder.Build(enumerable), dataBuilder.Build(enumerable), dateOnlyBuilder.Build(enumerable), fileNameBuilder.Build(enumerable), FileTypes.Audio),
            _ => throw new ArgumentException("Invalid file type.")
        };

        return fileMessage;
    }
}