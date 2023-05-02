using ChatProtocolRoyV2.DataModule;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2;

public class Packet : MessageBase
{
    #region fields

    #endregion
    
    #region Ctor

    public Packet(Guid id, MessageType type, byte[]data, MessageEdge Sync, MessageEdge Tail) : base(id, type)
    {
        Data = data;
        Sync = MessageEdge.Sync;
        Tail = MessageEdge.Tail;
    }

    #endregion

    #region properties
    
    public byte[] Data { get; }

    #endregion
    
}