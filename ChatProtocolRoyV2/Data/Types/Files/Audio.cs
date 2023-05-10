using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types.Files;

public class Audio : FileMessage
{
    #region Ctor
    
    public Audio(Guid guid, DateOnly dateOnly, string fileName, string dataInFile, string fileType)
        : base(guid, FileTypes.Audio, dateOnly, fileName, dataInFile, fileType)
    {
        
    }
    
    #endregion
    
    
    #region Properties
    
    #endregion
}