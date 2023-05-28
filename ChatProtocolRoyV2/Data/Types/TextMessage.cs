using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types;

public class TextMessage : MessageBase
{
    #region Ctor

    public TextMessage(Guid guid, string data) : base(guid, MessageType.TextMessage)
    {
        Data = data;
    }

    #endregion


    #region Properties

    public string Data { get; }

    #endregion
}