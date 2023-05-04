using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator;

public class Packet : MessageBase
{
    #region fields

    #endregion
    
    
    #region Ctor
    
    public Packet(Guid id, MessageType type, byte[]data, byte[] checksum, MessageEdge Sync, MessageEdge Tail) : base(id, type)
    {
        Data = data;
        Checksum = checksum;
        Sync = MessageEdge.Sync;
        Tail = MessageEdge.Tail;
    }
    
    #endregion

    
    #region properties
    
    public byte[] Data { get; }
    public byte[] Checksum { get; }
    
    #endregion
    
    //parser is the reverse process of the generator
    //TODO create a method to generate the packet, interface to generate what is needed
    //TODO expand the packet so the parser won't deal with low-level code, so instead of dealing with magic bytes it will get the type of file
    
}