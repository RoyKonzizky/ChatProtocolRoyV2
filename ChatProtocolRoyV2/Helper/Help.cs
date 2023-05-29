using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Helper;

public class Help
{
    public byte[] ObjectToByteArray<T>(T obj)
    {
        //TODO change from T to a more concrete types from this project, security concerns, use design patterns
        var concreteType = ConvertToConcreteType(obj);
        using var memoryStream = new MemoryStream();
        using var binaryWriter = new BinaryWriter(memoryStream);
        var objString = concreteType.ToString()!;
        binaryWriter.Write(objString);
        return memoryStream.ToArray();
    }

    public T FromByteArray<T>(byte[] byteArray)
    {
        using var memoryStream = new MemoryStream(byteArray);
        using var binaryReader = new BinaryReader(memoryStream);

        object objValue;

        if (typeof(T) == typeof(MessageType))
        {
            var messageType = (MessageType)binaryReader.ReadInt32();
            objValue = messageType;
        }
        else if (typeof(T) == typeof(Guid))
        {
            var guidBytes = binaryReader.ReadBytes(16);
            objValue = new Guid(guidBytes);
        }
        else if (typeof(T) == typeof(string))
        {
            objValue = binaryReader.ReadString();
        }
        else if (typeof(T) == typeof(int))
        {
            objValue = binaryReader.ReadInt32();
        }
        else if (typeof(T) == typeof(MessageEdge))
        {
            var messageEdge = (MessageEdge)binaryReader.ReadByte();
            objValue = messageEdge;
        }
        else if (typeof(T) == typeof(uint))
        {
            objValue = binaryReader.ReadUInt32();
        }
        else if (typeof(T) == typeof(DateOnly))
        {
            var dateOnlyString = binaryReader.ReadString();
            objValue = DateOnly.Parse(dateOnlyString);
        }
        else if (typeof(T) == typeof(FileTypes))
        {
            var fileType = (FileTypes)binaryReader.ReadInt32();
            objValue = fileType;
        }
        else
        {
            throw new ArgumentException("Unsupported type.");
        }

        return (T)ConvertToConcreteType(objValue);
    }


    private object ConvertToConcreteType<T>(T obj)
    {
        if (obj is MessageType or Guid or string or int or MessageEdge or uint or DateOnly or FileTypes)
        {
            return obj;
        }

        throw new ArgumentException("Unsupported type.");
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

    public byte[] CombineByteArrays(params byte[][] arrays)
    {
        return arrays.SelectMany(x => x).ToArray();
    }
}