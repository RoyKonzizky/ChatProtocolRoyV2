using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator;

public class Packet<T>
{
    public Packet(Guid id, MessageType type, T data, int checksum, MessageEdge sync, MessageEdge tail)
    {
        Id = id;
        Type = type;
        Data = data;
        Checksum = checksum;
        Sync = sync;
        Tail = tail;
    }

    #region Properties

    public Guid Id { get; }
    public MessageType Type { get; }
    public T Data { get; }
    public int Checksum { get; }
    public MessageEdge Sync { get; }
    public MessageEdge Tail { get; }

    #endregion
        
}

//parser is the reverse process of the generator
//TODO create a method to generate the packet, interface to generate what is needed
//TODO expand the packet so the parser won't deal with low-level code, so instead of dealing with magic bytes it will get the type of file
