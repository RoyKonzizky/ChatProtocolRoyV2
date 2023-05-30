using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator.Byte.Factory;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte;

public class ByteGenerator : IByteGenerator
{
    private readonly IChecksumByteArrayCalculator _checksumCalculator;
    private readonly IMessageGeneratorFactory _messageGeneratorFactory;
    private readonly IHelpBytes _helper;

    public ByteGenerator(IChecksumByteArrayCalculator checksumCalculator, IMessageGeneratorFactory messageGeneratorFactory, IHelpBytes helper)
    {
        _checksumCalculator = checksumCalculator;
        _messageGeneratorFactory = messageGeneratorFactory;
        _helper = helper;
    }

    public IEnumerable<byte> Generate(MessageBase messageBase)
    {
        if (messageBase == null)
            throw new ArgumentNullException(nameof(messageBase));

        var messageGenerator = _messageGeneratorFactory.CreateMessageGenerator(messageBase);
        var messageBytes = messageGenerator.GenerateMessageBytes();
        var checksumBytes = GenerateChecksumBytes(messageBytes);
        var syncBytes = _helper.ObjectToByteArray(MessageEdge.Sync);
        var tailBytes = _helper.ObjectToByteArray(MessageEdge.Tail);

        return _helper.CombineByteArrays(syncBytes, messageBytes, checksumBytes, tailBytes);
    }
    
    private byte[] GenerateChecksumBytes(IEnumerable<byte> dataBytes)
    {
        var checksum = _checksumCalculator.CalculateChecksum(dataBytes);
        return _helper.ObjectToByteArray(checksum);
    }

}