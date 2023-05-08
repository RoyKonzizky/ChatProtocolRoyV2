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

//TODO in this stage in the hirerachy instead of asking the user to input a type into the ctor, it can be done as seen above since we know it at this stage