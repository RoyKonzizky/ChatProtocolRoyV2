using System.Text;
using System.Text.Json;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator;

public class Generate
{
    public static Packet GeneratePacket(MessageEdge sync, object type,MessageBase data, uint checksum, MessageEdge tail)
    {
        var packet = new Packet(sync, type,data, checksum, tail);
        return packet;
    }

    public IEnumerable<byte> ObjectToByteArray<T>(T obj)
    {
        var options = new JsonSerializerOptions { WriteIndented = false };
        var jsonString = JsonSerializer.Serialize(obj, options);
        var byteArray = Encoding.UTF8.GetBytes(jsonString);
        return byteArray;
    }

    public T FromByteArray<T>(byte[] data)
    {
        var jsonString = Encoding.UTF8.GetString(data);
        var options = new JsonSerializerOptions();
        var obj = JsonSerializer.Deserialize<T>(jsonString, options);
        return obj!;
    }

    public static string FileDataToBase64(string filePath)
    {
        try
        {
            var fileBytes = File.ReadAllBytes(filePath);
            var base64String = Convert.ToBase64String(fileBytes);
            return base64String;
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
            return null!;
        }
    }

    public void Base64ToFileData(string base64String, string filePath)
    {
        try
        {
            var fileBytes = Convert.FromBase64String(base64String);
            File.WriteAllBytes(filePath, fileBytes);
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}

//why IEnumerable better-more flexible as it can return more specific types when needed in certain cases without breaking the footprint(Memory footprint refers to the amount of main memory that a program uses or references while running) of the method)
//This class's purpose is to take one type and translate it to a different one. if parser translate byte[]arr into message/packet, this class should convert packet into byte[]arr