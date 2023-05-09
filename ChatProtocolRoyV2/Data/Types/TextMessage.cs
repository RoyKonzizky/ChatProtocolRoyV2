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

//TODO in this stage in the hierarchy instead of asking the user to input a type into the ctor, it can be done as seen above since we know it at this stage