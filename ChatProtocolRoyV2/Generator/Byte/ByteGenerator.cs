using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator.Byte.Message;
using ChatProtocolRoyV2.Generator.Byte.Provider;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte;

public class ByteGenerator : IByteGenerator
{
    private readonly IChecksumByteArrayCalculator _checksumCalculator;
    private readonly IHelpBytes _helper;
    private readonly IMessageGeneratorProvider _messageGeneratorProvider;

    public ByteGenerator(IChecksumByteArrayCalculator checksumCalculator,
        IMessageGeneratorProvider messageGeneratorProvider, IHelpBytes helper)
    {
        _checksumCalculator = checksumCalculator;
        _messageGeneratorProvider = messageGeneratorProvider;
        _helper = helper;
    }

    public IEnumerable<byte> Generate(MessageBase messageBase)
    {
        if (messageBase == null)
            throw new ArgumentNullException(nameof(messageBase));

        var messageGenerator = GetMessageGenerator(messageBase);

        var messageBytes = messageGenerator.Generate(messageBase);
        var dataBytes = messageBytes.ToArray();
        var checksumBytes = GenerateChecksumBytes(dataBytes);
        var syncBytes = _helper.ObjectToByteArray(MessageEdge.Sync);
        var tailBytes = _helper.ObjectToByteArray(MessageEdge.Tail);
        var sharedBytes = GenerateSharedBytes(messageBase);

        return _helper.CombineByteArrays(syncBytes, sharedBytes.ToArray(), dataBytes, checksumBytes.ToArray(),
            tailBytes);
    }

    private IMessageGenerator GetMessageGenerator(MessageBase messageBase)
    {
        return _messageGeneratorProvider.Generate(messageBase);
    }

    private IEnumerable<byte> GenerateChecksumBytes(IEnumerable<byte> dataBytes)
    {
        var checksum = _checksumCalculator.CalculateChecksum(dataBytes);
        return _helper.ObjectToByteArray(checksum);
    }

    private IEnumerable<byte> GenerateSharedBytes(MessageBase messageBase)
    {
        return _helper.CombineByteArrays(
            _helper.ObjectToByteArray(messageBase.Id),
            _helper.ObjectToByteArray(messageBase.Type)
        );
    }
}
