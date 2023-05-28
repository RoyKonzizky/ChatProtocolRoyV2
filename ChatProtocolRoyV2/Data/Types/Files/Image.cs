using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types.Files;

public class Image : FileMessage
{
    #region Ctor

    public Image(Guid guid, DateOnly dateOnly, string fileName, string dataInFile, FileTypes fileType)
        : base(guid, MessageType.FileMessage, dateOnly, fileName, dataInFile, FileTypes.Image)
    {
    }

    #endregion
}

//TODO for audio too, remove the fileType or the FileTypes.Image/Audio as it is no longer needed