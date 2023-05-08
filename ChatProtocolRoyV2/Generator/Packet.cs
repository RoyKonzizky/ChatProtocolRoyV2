using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator;

public class Packet
{
    public Packet(MessageEdge sync, Guid id, MessageType type, MessageBase data, int checksum, MessageEdge tail)
    {
        Id = id;
        Type = type;
        Data = data;
        Checksum = checksum;
        Sync = sync;
        Tail = tail;
    }

    #region Properties

    public MessageEdge Sync { get; }
    public Guid Id { get; }
    private MessageType Type { get; }
    public MessageBase Data { get; }
    public int Checksum { get; }
    public MessageEdge Tail { get; }

    #endregion
        
}
