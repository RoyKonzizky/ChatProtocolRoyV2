using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types.Files;

public class Image : FileMessage
{
    #region Ctor
    
    public Image(Guid guid, string data, DateOnly dateOnly, string fileName)
        : base(guid, MessageType.FileMessage, data, dateOnly, fileName, FileTypes.Image)
    {
    }

    #endregion
}