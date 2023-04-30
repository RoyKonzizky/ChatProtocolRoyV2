using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2;

public class Packet : MessageBase
{
    public Packet(Guid id, MessageType type) : base(id, type)
    {
    }
}