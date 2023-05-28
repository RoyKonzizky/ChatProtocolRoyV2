using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types;

public abstract class FileMessage : MessageBase
{
    #region Ctor
    //TODO  change from object to messageType and correct if problems arise from the change
    protected FileMessage(Guid guid, MessageType type, DateOnly dateOnly, string fileName, string dataInFile,
        FileTypes fileType)
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