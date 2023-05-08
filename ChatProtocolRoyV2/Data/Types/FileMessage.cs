using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types;

public class FileMessage : MessageBase
{
    #region Ctor
    
    public FileMessage(Guid guid, MessageType type, DateOnly dateOnly, string fileName, string dataInFile, string fileType)
        : base(guid, type)
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