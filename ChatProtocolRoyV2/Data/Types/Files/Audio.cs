using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types.Files;

public class Audio : FileMessage
{
    #region Ctor
    
    public Audio(Guid guid, MessageType type, DateOnly dateOnly, string fileName, string dataInFile, string fileType)
        : base(guid, type, dateOnly, fileName, dataInFile, fileType)
    {
        
    }
    
    #endregion
   

    #region Properties
    
    #endregion
}