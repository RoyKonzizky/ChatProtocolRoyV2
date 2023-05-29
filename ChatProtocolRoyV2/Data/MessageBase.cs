using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data;

public abstract class MessageBase
{
    #region Ctor

    protected MessageBase(Guid id, MessageType type)
    {
        Id = id;
        Type = type;
    }

    #endregion

    #region Properties

    public Guid Id { get; }
    public MessageType Type { get; }

    #endregion
}