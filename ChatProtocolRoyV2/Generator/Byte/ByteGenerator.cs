using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator.Byte.Factory;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte;

public class ByteGenerator : IByteGenerator<MessageBase>
{
    private readonly IChecksumByteArrayCalculator _checksumCalculator;
    private readonly IHelpBytes _helper;
    private readonly IMessageGeneratorByteFactory _messageGeneratorFactory;

    public ByteGenerator(IChecksumByteArrayCalculator checksumCalculator,
        IMessageGeneratorByteFactory messageGeneratorFactory, IHelpBytes helper)
    {
        _checksumCalculator = checksumCalculator;
        _messageGeneratorFactory = messageGeneratorFactory;
        _helper = helper;
    }


    public IEnumerable<byte> Generate(MessageBase messageBase)
    {
        if (messageBase == null)
            throw new ArgumentNullException(nameof(messageBase));

        var dataBytes = _messageGeneratorFactory.Generate(messageBase);
        var dataBytesEnumerable = dataBytes as byte[] ?? dataBytes.ToArray();
        var checksumBytes = GenerateChecksumBytes(dataBytesEnumerable);
        var syncBytes = _helper.ObjectToByteArray(MessageEdge.Sync);
        var tailBytes = _helper.ObjectToByteArray(MessageEdge.Tail);
        var sharedBytes = GenerateSharedBytes(messageBase);
        var packet = syncBytes.Concat(sharedBytes.Concat(dataBytesEnumerable.Concat(checksumBytes.Concat(tailBytes))));
        return packet;
    }

    private IEnumerable<byte> GenerateChecksumBytes(IEnumerable<byte> dataBytes)
    {
        var checksum = _checksumCalculator.CalculateChecksum(dataBytes);
        return _helper.ObjectToByteArray(checksum);
    }

    private IEnumerable<byte> GenerateSharedBytes(MessageBase messageBase)
    {
        var guidBytes = _helper.ObjectToByteArray(messageBase.Id);
        var typeBytes = _helper.ObjectToByteArray(messageBase.Type);
        return guidBytes.Concat(typeBytes);
    }
}
//TODO try to eliminate use of the Helper in all classes