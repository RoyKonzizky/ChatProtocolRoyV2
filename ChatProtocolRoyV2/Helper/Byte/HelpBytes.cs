using ChatProtocolRoyV2.Entities;
using static ChatProtocolRoyV2.Constants.Encodings;

namespace ChatProtocolRoyV2.Helper.Byte;

// TODO: change from T to more concrete types from this project, address security concerns, use design patterns

public class HelpBytes : IHelpBytes
{
    public byte[] ObjectToByteArray<T>(T obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        var objString = obj.ToString()!;
        var byteArray = ASCII.GetBytes(objString);
        return byteArray;
    }

    public T FromByteArray<T>(byte[] byteArray)
    {
        if (byteArray == null)
            throw new ArgumentNullException(nameof(byteArray));

        T objValue;

        if (typeof(T) == typeof(MessageType))
        {
            var messageTypeValue = BitConverter.ToInt32(byteArray, 0);
            objValue = (T)(object)messageTypeValue;
        }
        else if (typeof(T) == typeof(Guid))
        {
            objValue = (T)(object)new Guid(byteArray);
        }
        else if (typeof(T) == typeof(string))
        {
            var decodedString = ASCII.GetString(byteArray);
            objValue = (T)(object)decodedString;
        }
        else if (typeof(T) == typeof(int))
        {
            var intValue = BitConverter.ToInt32(byteArray, 0);
            objValue = (T)(object)intValue;
        }
        else if (typeof(T) == typeof(MessageEdge))
        {
            var byteValue = byteArray[0];
            objValue = (T)(object)byteValue;
        }
        else if (typeof(T) == typeof(uint))
        {
            var uintValue = BitConverter.ToUInt32(byteArray, 0);
            objValue = (T)(object)uintValue;
        }
        else if (typeof(T) == typeof(DateOnly))
        {
            var decodedString = ASCII.GetString(byteArray);
            objValue = (T)(object)DateOnly.Parse(decodedString);
        }
        else if (typeof(T) == typeof(FileTypes))
        {
            var fileTypeValue = BitConverter.ToInt32(byteArray, 0);
            objValue = (T)(object)fileTypeValue;
        }
        else
        {
            throw new ArgumentException("Unsupported type.");
        }

        return objValue;
    }

    public IEnumerable<byte> CombineByteArrays(params byte[][] arrays)
    {
        return arrays.SelectMany(x => x).ToArray();
    }
}

