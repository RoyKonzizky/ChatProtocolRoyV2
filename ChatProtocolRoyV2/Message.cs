using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2;

public class Message
{
    #region fields
    public byte Sync = (byte)MessageEdge.Sync;
    public byte Tail = (byte)MessageEdge.Tail;
    private string _data;
    private byte _checkSum;
    private string _fileType;
    private Guid _id;
    #endregion

    #region Ctor
    public Message(byte checkSum, string data, string fileType, Guid id)
    {
        _checkSum = checkSum;
        _data = data;
        _fileType = fileType;
        _id = id;
    }
    #endregion
    
}