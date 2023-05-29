using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Tail;

public class TailBuilder : ITailBuilder
{
    public MessageEdge Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var tailBytes = Array.Empty<byte>();
        Array.Copy(inputBytes, inputBytes[^1], tailBytes, 0, 1);
        var helper = new HelpBytes();
        var tail = helper.FromByteArray<MessageEdge>(tailBytes);
        return tail;
    }
}