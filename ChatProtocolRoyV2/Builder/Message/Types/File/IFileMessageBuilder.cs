using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Builder.Message.Types.File;

public interface IFileMessageBuilder : IMessageBuilder
{
    IFileMessageBuilder WithFileName(string fileName);
    IFileMessageBuilder WithFileContent(string fileContent);
    IFileMessageBuilder WithDateOnly(DateOnly dateOnly);
    IFileMessageBuilder WithFileType(FileTypes fileType);
}