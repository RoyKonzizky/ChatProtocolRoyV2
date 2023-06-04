using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Data.Types.Files;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.DateOnly;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.FileName;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.FileType;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Guid;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.File;

public class FileMessageBuilder : IFileMessageBuilder
{
    private readonly IDataBuilder _dataBuilder;
    private readonly IDateOnlyBuilder _dateOnlyBuilder;
    private readonly IFileNameBuilder _fileNameBuilder;
    private readonly IFileTypeBuilder _fileTypeBuilder;
    private readonly IGuidBuilder _guidBuilder;

    public FileMessageBuilder(IGuidBuilder guidBuilder, IDataBuilder dataBuilder, IFileTypeBuilder fileTypeBuilder,
        IFileNameBuilder fileNameBuilder, IDateOnlyBuilder dateOnlyBuilder)
    {
        _guidBuilder = guidBuilder;
        _dataBuilder = dataBuilder;
        _fileTypeBuilder = fileTypeBuilder;
        _fileNameBuilder = fileNameBuilder;
        _dateOnlyBuilder = dateOnlyBuilder;
    }

    public FileMessage Build(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();

        FileMessage fileMessage = _fileTypeBuilder.Build(enumerable) switch
        {
            FileTypes.Image => new Image(_guidBuilder.Build(enumerable), _dataBuilder.Build(enumerable),
                _dateOnlyBuilder.Build(enumerable), _fileNameBuilder.Build(enumerable)),
            FileTypes.Audio => new Audio(_guidBuilder.Build(enumerable), _dataBuilder.Build(enumerable),
                _dateOnlyBuilder.Build(enumerable), _fileNameBuilder.Build(enumerable)),
            _ => throw new ArgumentException("Invalid file type.")
        };

        return fileMessage;
    }
}