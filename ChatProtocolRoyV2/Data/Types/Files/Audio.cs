using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types.Files;

public class Audio : FileMessage
{
    #region Ctor

    public Audio(Guid guid, string data, DateOnly dateOnly, string fileName)
        : base(guid, MessageType.FileMessage, data, dateOnly, fileName, FileTypes.Audio)
    {
    }

    #endregion
}