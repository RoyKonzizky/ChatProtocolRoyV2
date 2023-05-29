using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator.Byte;

public class ByteGenerator : IByteGenerator
{
    //TODO make sure no problem arise from the change in the method
    //TODO maybe write methods to clean the methods as it does multiple things
    public IEnumerable<byte> Generate(MessageBase messageBase)
    {
        var sync = MessageEdge.Sync;
        var id = messageBase.Id;
        var type = messageBase.Type;

        int dataLength;
        string data;
        uint checksum;
        var tail = MessageEdge.Tail;

        var calculator = new ChecksumByteArrayCalculator();
        
        byte[] completeByteArray;

        switch (type)
        {
            case MessageType.FileMessage:
            {
                var fileMessage = (FileMessage)messageBase;
                var fileType = fileMessage.FileType;
                var dateOnly = fileMessage.DateOnly;
                var fileName = fileMessage.FileName;

                data = fileMessage.Data;
                dataLength = data.Length;
                checksum = calculator.CalculateChecksum(ObjectToByteArray(data));

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
                var textMessage = (TextMessage)messageBase;
                data = textMessage.Data;
                dataLength = data.Length;
                checksum = calculator.CalculateChecksum(ObjectToByteArray(data));

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
    
    //TODO helper method module
    public byte[] ObjectToByteArray<T>(T obj)
    {
        //TODO change from T to a more concrete types from this project, security concerns
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