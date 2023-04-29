using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Data.Types;

public class File : MessageBase
{
    #region Ctor
    public File(Guid guid, MessageType type, string dataInFile, string fileType) : base(guid, type)
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