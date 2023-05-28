using System.Collections;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator.Byte;

public class ByteGenerator : IByteGenerator
{
    public IEnumerable<byte> Generate(ArrayList arrList)
    {
        //TODO use constants with the arraylist or dict instead of the arraylist
        //TODO maybe write methods to clean the methods as it does multiple things
        var sync = (MessageEdge)arrList[0]!;
        var id = (Guid)arrList[1]!;
        var type = (MessageType)arrList[2]!;

        int dataLength;
        string data;
        uint checksum;
        MessageEdge tail;

        byte[] completeByteArray;

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

                completeByteArray = CombineByteArrays(ObjectToByteArray(sync),
                    ObjectToByteArray(id), ObjectToByteArray(type),
                    ObjectToByteArray(fileType), ObjectToByteArray(dateOnly), ObjectToByteArray(fileName),
                    ObjectToByteArray(dataLength), ObjectToByteArray(data),
                    ObjectToByteArray(checksum),
                    ObjectToByteArray(tail));

                return completeByteArray;
            }

            case MessageType.TextMessage:
            {
                dataLength = (int)arrList[3]!;
                data = (string)arrList[4]!;
                checksum = (uint)arrList[5]!;
                tail = (MessageEdge)arrList[6]!;

                completeByteArray = CombineByteArrays(ObjectToByteArray(sync),
                    ObjectToByteArray(id), ObjectToByteArray(type),
                    ObjectToByteArray(dataLength), ObjectToByteArray(data),
                    ObjectToByteArray(checksum),
                    ObjectToByteArray(tail));

                return completeByteArray;
            }

            default:
            {
                throw new Exception("Invalid type");
            }
        }
    }

    public byte[] ObjectToByteArray<T>(T obj)
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

    private static byte[] CombineByteArrays(params byte[][] arrays)
    {
        return arrays.SelectMany(x => x).ToArray();
    }
}

//why IEnumerable better-more flexible as it can return more specific types when needed in certain cases without breaking the footprint(Memory footprint refers to the amount of main memory that a program uses or references while running) of the method)
//This class's purpose is to take one type and translate it to a different one. if parser translate byte[]arr into message/packet, this class should convert packet into byte[]arr