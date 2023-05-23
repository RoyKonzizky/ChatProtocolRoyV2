using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator;
using ChatProtocolRoyV2.Generator.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Type;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;

public class DataBuilder : IDataBuilder
{
    public string Build(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();        
        var typeBuilder = new TypeBuilder();
        var type = typeBuilder.Build(enumerable);
        var inputBytes = enumerable.ToArray();
        var dataBytes = Array.Empty<byte>();
        var lengthBuilder = new LengthBuilder();
        var generator = new Generate();
        string data;
        switch (type)
        {
            case MessageType.TextMessage:
                Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX_FILE + 1, dataBytes, 0, lengthBuilder.Build(enumerable));
                data = generator.FromByteArray<string>(dataBytes);
                return data;
            case MessageType.FileMessage:
                Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX_FILE + 1, dataBytes, 0, lengthBuilder.Build(enumerable));
                data = generator.FromByteArray<string>(dataBytes);
                return data;

            default:
                throw new Exception("no matching type");
        }
        
    }
}