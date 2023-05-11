namespace ChatProtocolRoyV2.Data;

public abstract class MessageBase
{
    #region Ctor

    protected MessageBase(Guid id, object type)
    {
        Id = id;
        Type = type;
    }

    #endregion

    #region Properties

    private Guid Id { get; }
    private object Type { get; }

    #endregion
}

//maybe the decorator/wrapper can solve the problem and change it to messageType from object