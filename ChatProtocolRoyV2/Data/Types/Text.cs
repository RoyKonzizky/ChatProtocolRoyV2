using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types;

public class Text : MessageBase
{
    #region Ctor
    public Text(Guid guid, MessageType type, string data) : base(guid, type)
    {
        Data = data;
    }
    #endregion
   

    #region Properties
    public string Data { get; }
    #endregion
}