using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.File;
using ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.Text;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Checksum;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Type;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Director;

public class Director : IDirector
{
    private readonly IChecksumBuilder _checksumBuilder;
    private readonly IChecksumByteArrayCalculator _checksumByteArrayCalculator;
    private readonly IDataBuilder _dataBuilder;
    private readonly IFileMessageBuilder _fileMessageBuilder;
    private readonly IHelpBytes _helper;
    private readonly ITextMessageBuilder _textMessageBuilder;
    private readonly ITypeBuilder _typeBuilder;

    public Director(ITypeBuilder typeBuilder, IChecksumBuilder checksumBuilder, IDataBuilder dataBuilder,
        ITextMessageBuilder textMessageBuilder, IFileMessageBuilder fileMessageBuilder,
        IHelpBytes helper, IChecksumByteArrayCalculator checksumByteArrayCalculator)
    {
        _typeBuilder = typeBuilder;
        _checksumBuilder = checksumBuilder;
        _dataBuilder = dataBuilder;
        _textMessageBuilder = textMessageBuilder;
        _fileMessageBuilder = fileMessageBuilder;
        _helper = helper;
        _checksumByteArrayCalculator = checksumByteArrayCalculator;
    }

    public MessageBase Build(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();
        var type = _typeBuilder.Build(enumerable);
        var checksum = _checksumBuilder.Build(enumerable);
        var data = _dataBuilder.Build(enumerable);

        var checksumFromMessageData = _checksumByteArrayCalculator.CalculateChecksum(_helper.ObjectToByteArray(data));

        if (checksum != checksumFromMessageData)
            throw new Exception("Checksums do not match, message has been corrupted");

        MessageBase messageBase = type switch
        {
            MessageType.TextMessage => _textMessageBuilder.Build(enumerable),
            MessageType.FileMessage => _fileMessageBuilder.Build(enumerable),
            _ => throw new Exception("Invalid type")
        };

        return messageBase;
    }
}