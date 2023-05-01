using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.DataModule.Types;

public class TextMessage : MessageBase
{
    #region Ctor

    public TextMessage(Guid guid, MessageType type, string data) : base(guid, type)
    {
        Data = data;
    }

    #endregion


    #region Properties

    public string Data { get; }

    #endregion
}