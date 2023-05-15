using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Builder.Message.Types;

public class FileMessageBuilder : IMessageBuilder
{
    private Guid _guid;
    private string _text = null!;
    private string _fileName = null!;
    private string _fileContent = null!;
    private DateOnly _dateOnly;
    private FileTypes _fileType;

    public IMessageBuilder WithGuid(Guid guid)
    {
        _guid = guid;
        return this;
    }

    public IMessageBuilder WithText(string text)
    {
        _text = text;
        return this;
    }

    public IMessageBuilder WithFile(string fileName, string fileContent, DateOnly dateOnly, FileTypes fileType)
    {
        _fileName = fileName;
        _fileContent = fileContent;
        _dateOnly = dateOnly;
        _fileType = fileType;
        return this;
    }

    public MessageBase Build(object input)
    {
        var fileMessage = new FileMessage(_guid, _fileName, _fileContent, _dateOnly, _fileType);

        // Reset the builder state
        _guid = default;
        _text = default;
        _fileName = default;
        _fileContent = default;
        _dateOnly = default;
        _fileType = default;

        return fileMessage;
    }
}
//TODO find way to consturct a different version for each type since filemessage is abstract
