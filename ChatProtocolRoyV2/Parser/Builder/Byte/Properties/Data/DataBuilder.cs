using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;

public class DataBuilder : IDataBuilder
{
    private readonly ILengthBuilder _lengthBuilder;

    public DataBuilder(ILengthBuilder lengthBuilder)
    {
        _lengthBuilder = lengthBuilder;
    }

    public string Build(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();
        var inputBytes = enumerable.ToArray();
        var dataBytes = Array.Empty<byte>();
        var helper = new HelpBytes();
        Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX + 1, dataBytes, 0,
            _lengthBuilder.Build(enumerable));
        var data = helper.FromByteArray<string>(dataBytes);
        return data;
    }
}