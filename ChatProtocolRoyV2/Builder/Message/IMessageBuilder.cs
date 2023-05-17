using ChatProtocolRoyV2.Builder.Properties.Type;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Builder.Message;

public interface IMessageBuilder : IBuilder<Guid,>
{
    IMessageBuilder WithGuid(Guid guid);
}