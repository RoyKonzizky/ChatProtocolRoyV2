using System.Text;
using System.Text.Json;
using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Generator;

public class Generate
{
    public static byte[] GenerateBinaryArrayFromPacket<T>(Packet<T> packet)
    {
        string jsonString = JsonSerializer.Serialize(packet.Data);
        byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
        return byteArray;
    }
}