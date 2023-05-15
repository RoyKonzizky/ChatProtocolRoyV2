using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types;

public abstract class FileMessage : MessageBase
{
    #region Ctor

    protected FileMessage(Guid guid, object type, DateOnly dateOnly, string fileName, string dataInFile, FileTypes fileType)
        : base(guid, MessageType.FileMessage)
    {
        FileName = fileName;
        DateOnly = dateOnly;
        DataInFile = dataInFile;
        FileType = fileType;
    }

    #endregion


    #region Properties

    public DateOnly DateOnly { get; }
    public string DataInFile { get; }
    public FileTypes FileType { get; }
    public string FileName { get; }

    #endregion
}

