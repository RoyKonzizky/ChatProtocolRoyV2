using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Sync;

public class SyncBuilder : ISyncBuilder
{
    public MessageEdge Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var syncBytes = Array.Empty<byte>();
        Array.Copy(inputBytes, Indexes.SYNC_INDEX, syncBytes, 0, 1);
        var generator = new Generate();
        var sync = generator.FromByteArray<MessageEdge>(syncBytes);
        return sync;
    }
}