using System.Collections;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator.Byte;

public class Generate : IGenerateBytes
{
    public IEnumerable<byte> GeneratePacket(ArrayList arrList)
    {
        var arrayList = new ArrayList();
        Generate generator = null!;
        
        var sync = (MessageEdge)arrList[0]!;
        var id = (Guid)arrList[1]!;
        var type = (MessageType)arrList[2]!;

        int dataLength;
        string data;
        uint checksum;
        MessageEdge tail;
        
        IEnumerable<byte> arr;

        switch (type)
        {
            case MessageType.FileMessage:
            {
                var fileType = (FileTypes)arrList[3]!;
                var dateOnly = (DateOnly)arrList[4]!;
                var fileName = (string)arrList[5]!;

                dataLength = (int)arrList[6]!;
                data = (string)arrList[7]!;
                checksum = (uint)arrList[8]!;
                tail = (MessageEdge)arrList[9]!;

                arrayList.Add(generator.ObjectToByteArray(sync));
                arrayList.Add(generator.ObjectToByteArray(id));
                arrayList.Add(generator.ObjectToByteArray(type));

                arrayList.Add(generator.ObjectToByteArray(fileType));
                arrayList.Add(generator.ObjectToByteArray(dateOnly));
                arrayList.Add(generator.ObjectToByteArray(fileName));

                arrayList.Add(generator.ObjectToByteArray(dataLength));
                arrayList.Add(generator.ObjectToByteArray(data));
                
                arrayList.Add(generator.ObjectToByteArray(checksum));
                arrayList.Add(generator.ObjectToByteArray(tail));
                
                arr = generator.ObjectToByteArray(arrayList);

                return arr;
            }
            
            case MessageType.TextMessage:
            {
                dataLength = (int)arrList[3]!;
                data = (string)arrList[4]!;
                checksum = (uint)arrList[5]!;
                tail = (MessageEdge)arrList[6]!;

                arrayList.Add(generator.ObjectToByteArray(sync));
                arrayList.Add(generator.ObjectToByteArray(id));
                arrayList.Add(generator.ObjectToByteArray(type));
                
                arrayList.Add(generator.ObjectToByteArray(dataLength));
                arrayList.Add(generator.ObjectToByteArray(data));
                
                arrayList.Add(generator.ObjectToByteArray(checksum));
                arrayList.Add(generator.ObjectToByteArray(tail));
                
                arr = generator.ObjectToByteArray(arrayList);

                return arr;
            }

            default:
            {
                throw new Exception("Invalid type");
            }
        }
    }
    
    public IEnumerable<byte> ObjectToByteArray<T>(T obj)
    {
        using var memoryStream = new MemoryStream();
        using var binaryWriter = new BinaryWriter(memoryStream);
        var objString = obj!.ToString()!;
        binaryWriter.Write(objString);
        return memoryStream.ToArray();
    }

    public T FromByteArray<T>(byte[] byteArray)
    {
        using var memoryStream = new MemoryStream(byteArray);
        using var binaryReader = new BinaryReader(memoryStream);
        var objString = binaryReader.ReadString();
        return (T)(object)objString;
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