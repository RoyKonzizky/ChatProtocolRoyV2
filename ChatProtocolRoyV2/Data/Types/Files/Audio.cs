using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types.Files;

public class Audio : FileMessage
{
    #region Ctor

    public Audio(Guid guid, DateOnly dateOnly, string fileName, string dataInFile, FileTypes fileType)
        : base(guid, MessageType.FileMessage, dateOnly, fileName, dataInFile, FileTypes.Audio)
    {
    }

    #endregion
}