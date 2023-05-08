using System.Text;
using System.Text.Json;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator;

public class Generate
{
    public static Packet GeneratePacket<T>(MessageEdge sync, Guid id, MessageType type, MessageBase data, int checksum, MessageEdge tail)
    {
        Packet packet = new Packet(sync, id, type, data, checksum, tail);
        return packet;
    }
    public static byte[] GenerateBinaryArrayFromPacket<T>(Packet packet)
    {
        var jsonString = JsonSerializer.Serialize(packet.Data);
        var byteArray = Encoding.UTF8.GetBytes(jsonString);
        return byteArray;
    }
}
//TODO instead IEnumerable instead of byte array and why its better
//TODO method to validate the checksum, and pull the sync tail and checksum
//define size for each part of the packet