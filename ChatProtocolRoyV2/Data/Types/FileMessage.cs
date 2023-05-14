using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types;

public class FileMessage : MessageBase
{
    #region Ctor

    public FileMessage(Guid guid, object type, DateOnly dateOnly, string fileName, string dataInFile, string fileType)
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
    public string FileType { get; }
    public string FileName { get; }

    #endregion
}

//i may be wrong about it but maybe the FileTypes enum was for the FileType in this class