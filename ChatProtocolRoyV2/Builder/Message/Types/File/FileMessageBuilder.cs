using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types.Files;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Builder.Message.Types.File;

public class FileMessageBuilder : IFileMessageBuilder
{
    private Guid _guid;
    private string _fileName = null!;
    private string _fileContent = null!;
    private DateOnly _dateOnly;
    private FileTypes _fileType;

    public IMessageBuilder WithGuid(Guid guid)
    {
        _guid = guid;
        return this;
    }

    public IFileMessageBuilder WithFileName(string fileName)
    {
        _fileName = fileName;
        return this;
    }

    public IFileMessageBuilder WithFileContent(string fileContent)
    {
        _fileContent = fileContent;
        return this;
    }

    public IFileMessageBuilder WithDateOnly(DateOnly dateOnly)
    {
        _dateOnly = dateOnly;
        return this;
    }

    public IFileMessageBuilder WithFileType(FileTypes fileType)
    {
        _fileType = fileType;
        return this;
    }

    public MessageBase Build<T>(T input)
    {
        MessageBase fileMessage = _fileType switch
        {
            FileTypes.Image => new Image(_guid, _dateOnly, _fileName, _fileContent, FileTypes.Image),
            FileTypes.Audio => new Audio(_guid, _dateOnly, _fileName, _fileContent, FileTypes.Audio),
            _ => throw new ArgumentException("Invalid file type.")
        };

        return fileMessage;
    }
}