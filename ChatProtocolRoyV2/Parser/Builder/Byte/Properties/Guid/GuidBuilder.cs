using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Guid;

public class GuidBuilder : IGuidBuilder
{
    private readonly IHelpBytes _helper;

    public GuidBuilder(IHelpBytes helper)
    {
        _helper = helper;
    }

    public System.Guid Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var guidBytes = Array.Empty<byte>();
        Array.Copy(inputBytes, Indexes.GUID_INDEX, guidBytes, 0, 16);
        var data = _helper.FromByteArray<System.Guid>(guidBytes);
        return data;
    }
}