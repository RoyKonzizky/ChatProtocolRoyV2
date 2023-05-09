using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator;

public class Generate
{
    public static Packet GeneratePacket<T>(MessageEdge sync, MessageBase data, int checksum, MessageEdge tail)
    {
        Packet packet = new Packet(sync, data, checksum, tail);
        return packet;
    }
    public static IEnumerable<byte> ObjectToByteArray<T>(T obj)
    {
        var options = new JsonSerializerOptions { WriteIndented = false };
        var jsonString = JsonSerializer.Serialize(obj, options);
        var byteArray = Encoding.UTF8.GetBytes(jsonString);
        return byteArray;
    }

    public static T FromByteArray<T>(byte[] data)
    {
        var jsonString = Encoding.UTF8.GetString(data);
        var options = new JsonSerializerOptions();
        var obj = JsonSerializer.Deserialize<T>(jsonString, options);
        return obj ?? throw new InvalidOperationException();
    }

}
//TODO instead IEnumerable instead of byte array
//why its better-more flexible as it can return more specific types when needed in certain cases without breaking the footprint(Memory footprint refers to the amount of main memory that a program uses or references while running) of the method)
//define size for each part of the packet