using ChatProtocolRoyV2.Entities;

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
    public Guid Id { get; }
    public object Type{ get;  }
    #endregion
    
}