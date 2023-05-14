using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator;

public class Packet
{
    public Packet(MessageEdge sync, object type,MessageBase data, uint checksum, MessageEdge tail)
    {
        Data = data;
        Type = type;
        Checksum = checksum;
        Sync = sync;
        Tail = tail;
    }

    #region Properties

    public MessageEdge Sync { get; }
    public MessageBase Data { get; }
    public uint Checksum { get; }
    public MessageEdge Tail { get; }
    public object Type { get; }

    #endregion
}


//DELETE THIS CLASS BECAUSE IT HARMS FLEXIBILITY AND REPLACE IT WITH THE BUILDERS AND CREATE BYTE ARRAY

