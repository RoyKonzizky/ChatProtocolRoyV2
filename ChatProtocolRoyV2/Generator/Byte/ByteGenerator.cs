using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator.Byte.Factory;
using ChatProtocolRoyV2.Generator.Byte.Message;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte;

public class ByteGenerator : IByteGenerator
{
    private readonly IChecksumByteArrayCalculator _checksumCalculator;
    private readonly IMessageGeneratorFactory _messageGeneratorFactory;
    private readonly IHelpBytes _helper;

    public ByteGenerator(IChecksumByteArrayCalculator checksumCalculator, 
        IMessageGeneratorFactory messageGeneratorFactory, IHelpBytes helper)
    {
        _checksumCalculator = checksumCalculator;
        _messageGeneratorFactory = messageGeneratorFactory;
        _helper = helper;
    }

    public IEnumerable<byte> Generate(MessageBase messageBase)
    {
        if (messageBase == null)
            throw new ArgumentNullException(nameof(messageBase));

        var messageGenerator = GetMessageGenerator(messageBase);
        var messageBytes = messageGenerator.GenerateMessageBytes(messageBase);
        var dataBytes = messageBytes.ToArray();
        var checksumBytes = GenerateChecksumBytes(dataBytes);
        var syncBytes = _helper.ObjectToByteArray(MessageEdge.Sync);
        var tailBytes = _helper.ObjectToByteArray(MessageEdge.Tail);

        return _helper.CombineByteArrays(syncBytes, dataBytes, checksumBytes.ToArray(), tailBytes);
    }

    private IMessageGenerator GetMessageGenerator(MessageBase messageBase)
    {
        return _messageGeneratorFactory.CreateMessageGenerator(messageBase);
    }

    private IEnumerable<byte> GenerateChecksumBytes(IEnumerable<byte> dataBytes)
    {
        var checksum = _checksumCalculator.CalculateChecksum(dataBytes);
        return _helper.ObjectToByteArray(checksum);
    }
}