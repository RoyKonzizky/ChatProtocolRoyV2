using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator;

public class Packet
{
    public Packet(MessageEdge sync, MessageBase data, int checksum, MessageEdge tail)
    {
        Data = data;
        Checksum = checksum;
        Sync = sync;
        Tail = tail;
    }

    #region Properties

    public MessageEdge Sync { get; }
    public MessageBase Data { get; }
    public int Checksum { get; }
    public MessageEdge Tail { get; }

    #endregion
        
}
