using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Sync;

public class SyncBuilder : ISyncBuilder
{
    private readonly IHelpBytes _helper;

    public SyncBuilder(IHelpBytes helper)
    {
        _helper = helper;
    }

    public MessageEdge Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var syncBytes = Array.Empty<byte>();
        Array.Copy(inputBytes, Indexes.SYNC_INDEX, syncBytes, 0, 1);
        var sync = _helper.FromByteArray<MessageEdge>(syncBytes);
        return sync;
    }
}