using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Guid;

public class GuidBuilder : IGuidBuilder
{
    public System.Guid Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var guidBytes = Array.Empty<byte>();
        Array.Copy(inputBytes, Indexes.GUID_INDEX, guidBytes, 0, 16);
        var helper = new HelpBytes();
        var data = helper.FromByteArray<System.Guid>(guidBytes);
        return data;
    }
}