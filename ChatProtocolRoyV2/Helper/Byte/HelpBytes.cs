using System.Text;
using ChatProtocolRoyV2.Entities;
using static ChatProtocolRoyV2.Constants.Encodings;

namespace ChatProtocolRoyV2.Helper.Byte;

public class HelpBytes : IHelpBytes
{
    private Dictionary<Type, Func<IEnumerable<byte>, object>> _conversionMap = null!;

    public HelpBytes()
    {
        InitializeConversionMap();
    }

    public IEnumerable<byte> ObjectToByteArray<T>(T obj)
    {
        if (obj == null)
            throw new ArgumentNullException(nameof(obj));

        var objString = obj.ToString()!;
        var byteArray = ASCII.GetBytes(objString);
        return byteArray;
    }

    public T FromByteArray<T>(IEnumerable<byte> byteArray)
    {
        if (byteArray == null)
            throw new ArgumentNullException(nameof(byteArray));

        if (!_conversionMap.TryGetValue(typeof(T), out var conversionFunc))
            throw new ArgumentException("Unsupported type.");

        return (T)conversionFunc(byteArray);
    }

    private void InitializeConversionMap()
    {
        _conversionMap = new Dictionary<Type, Func<IEnumerable<byte>, object>>
        {
            { typeof(MessageType), bytes => BitConverter.ToInt32(bytes.ToArray(), 0) },
            { typeof(Guid), bytes => new Guid(bytes.ToArray()) },
            { typeof(string), bytes => ASCII.GetString(bytes.ToArray()) },
            { typeof(int), bytes => BitConverter.ToInt32(bytes.ToArray(), 0) },
            { typeof(MessageEdge), bytes => bytes.First() },
            { typeof(uint), bytes => BitConverter.ToUInt32(bytes.ToArray(), 0) },
            { typeof(DateOnly), bytes => DateOnly.Parse(ASCII.GetString(bytes.ToArray())) },
            { typeof(FileTypes), bytes => BitConverter.ToInt32(bytes.ToArray(), 0) }
        };
    }


    public IEnumerable<byte> CombineByteArrays(IEnumerable<byte[]> arrays)
    {
        return arrays.SelectMany(x => x);
    }
}

