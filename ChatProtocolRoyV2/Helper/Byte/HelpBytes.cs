using ChatProtocolRoyV2.Entities;
using static ChatProtocolRoyV2.Constants.Encodings;

namespace ChatProtocolRoyV2.Helper.Byte;

public class HelpBytes : IHelpBytes
{
    private Dictionary<Type, Func<byte[], object>> _conversionMap = null!;

    public HelpBytes()
    {
        InitializeConversionMap();
    }

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

        if (!_conversionMap.TryGetValue(typeof(T), out var conversionFunc))
            throw new ArgumentException("Unsupported type.");

        return (T)conversionFunc(byteArray);
    }

    public IEnumerable<byte> CombineByteArrays(byte[][] arrays)
    {
        return arrays.SelectMany(x => x).ToArray();
    }

    private void InitializeConversionMap()
    {
        _conversionMap = new Dictionary<Type, Func<byte[], object>>
        {
            { typeof(MessageType), bytes => BitConverter.ToInt32(bytes, 0) },
            { typeof(Guid), bytes => new Guid(bytes) },
            { typeof(string), bytes => ASCII.GetString(bytes) },
            { typeof(int), bytes => BitConverter.ToInt32(bytes, 0) },
            { typeof(MessageEdge), bytes => bytes[0] },
            { typeof(uint), bytes => BitConverter.ToUInt32(bytes, 0) },
            { typeof(DateOnly), bytes => DateOnly.Parse(ASCII.GetString(bytes)) },
            { typeof(FileTypes), bytes => BitConverter.ToInt32(bytes, 0) }
        };
    }
}