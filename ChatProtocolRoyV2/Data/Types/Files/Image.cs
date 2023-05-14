using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types.Files;

public class Image : FileMessage
{
    #region Ctor

    public Image(Guid guid, DateOnly dateOnly, string fileName, string dataInFile, FileTypes fileType)
        : base(guid, FileTypes.Image, dateOnly, fileName, dataInFile, fileType)
    {
    }

    #endregion
}