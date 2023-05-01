using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.DataModule.Types;

public class FileMessage : MessageBase
{
    #region Ctor
    
    public FileMessage(Guid guid, MessageType type, string dataInFile, string fileType) : base(guid, type)
    {
        DataInFile = dataInFile;
        FileType = fileType;
    }
    
    #endregion
   

    #region Properties
    
    public string DataInFile { get; }
    public string FileType { get; }
    
    #endregion
}