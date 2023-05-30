using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Message;
using ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.File;
using ChatProtocolRoyV2.Parser.Builder.Byte.Message.Types.Text;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Checksum;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Type;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Director;

public class Director : IDirector
{
    private readonly ITypeBuilder _typeBuilder;
    private readonly IChecksumBuilder _checksumBuilder;
    private readonly IDataBuilder _dataBuilder;
    private readonly IMessageBuilder<FileMessage> _fileMessageBuilder;
    private readonly IMessageBuilder<TextMessage> _textMessageBuilder;
    private readonly IChecksumByteArrayCalculator _checksumByteArrayCalculator;
    private readonly IHelpBytes _helper;
    //TODO FileMessage and TextMessage builder interfaces to not use IMessageBuilder
    public Director(ITypeBuilder typeBuilder, IChecksumBuilder checksumBuilder, IDataBuilder dataBuilder, 
        IMessageBuilder<TextMessage> textMessageBuilder, IMessageBuilder<FileMessage> fileMessageBuilder,
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
        var checksum =_checksumBuilder.Build(enumerable);
        var data = _dataBuilder.Build(enumerable);

        var textMessageBuilder = new TextMessageBuilder();
        var fileMessageBuilder = new FileMessageBuilder();

        var checksumFromMessageData = _checksumByteArrayCalculator.CalculateChecksum
            (_helper.ObjectToByteArray(data));


        if (checksum != checksumFromMessageData)
            throw new Exception("Checksums do not match, message has been corrupted");
        var messageBase = type switch
        {
            MessageType.TextMessage => textMessageBuilder.Build(enumerable),
            MessageType.FileMessage => fileMessageBuilder.Build(enumerable),
            _ => throw new Exception("Invalid type")
        };
        return messageBase;
    }
}