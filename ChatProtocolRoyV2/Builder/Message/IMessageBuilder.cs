using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Builder.Message;

public interface IMessageBuilder : IBuilder<MessageBase, object>
{
    IMessageBuilder WithGuid(Guid guid);
    IMessageBuilder WithText(string text);
    IMessageBuilder WithFile(string fileName, string fileContent, DateOnly dateOnly, FileTypes fileType);
}