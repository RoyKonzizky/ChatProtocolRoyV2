using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types;

public class TextMessage : MessageBase
{
    #region Ctor

    public TextMessage(Guid guid, string content) : base(guid, MessageType.TextMessage)
    {
        Content = content;
    }

    #endregion


    #region Properties

    public string Content { get; }

    #endregion
}