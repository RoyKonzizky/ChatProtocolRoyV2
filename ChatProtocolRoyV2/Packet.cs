using ChatProtocolRoyV2.DataModule;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2;

public class Packet : MessageBase
{
    #region Ctor

    public Packet(Guid id, MessageType type, byte[] checksum, string data, MessageEdge sync, MessageEdge tail) : base(id, type)
    {
        
    }

    #endregion

    #region properties

    #endregion
}