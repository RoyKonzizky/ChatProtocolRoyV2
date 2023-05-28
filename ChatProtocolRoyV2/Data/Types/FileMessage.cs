using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types;

public abstract class FileMessage : MessageBase
{
    #region Ctor
    protected FileMessage(Guid guid, MessageType type, string data,
        DateOnly dateOnly, string fileName,
        FileTypes fileType)
        : base(guid, MessageType.FileMessage)
    {
        FileName = fileName;
        DateOnly = dateOnly;
        Data = data;
        FileType = fileType;
    }

    #endregion


    #region Properties

    public DateOnly DateOnly { get; }
    public string Data { get; }
    public FileTypes FileType { get; }
    public string FileName { get; }

    #endregion
}