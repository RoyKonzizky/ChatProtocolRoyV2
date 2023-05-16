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

    public MessageBase Build(object input)
    {
        MessageBase fileMessage;
            
        if (_fileType == FileTypes.Image)
        {
            fileMessage = new Image(_guid, _dateOnly, _fileName, _fileContent, FileTypes.Image);
        }
        else if (_fileType == FileTypes.Audio)
        {
            fileMessage = new Audio(_guid, _dateOnly, _fileName, _fileContent,FileTypes.Audio);
        }
        else
        {
            throw new ArgumentException("Invalid file type.");
        }

        // Reset builder state
        _guid = Guid.Empty;
        _fileName = null!;
        _fileContent = null!;
        _dateOnly = default;
        _fileType = default;

        return fileMessage;
    }
}