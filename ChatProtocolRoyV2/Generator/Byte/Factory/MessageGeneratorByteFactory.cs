using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte.Factory;

public class MessageGeneratorByteFactory
{
    private readonly IHelpBytes _helper;

    public MessageGeneratorByteFactory()
    {
        _helper = new HelpBytes();
    }

    public IEnumerable<byte> Generate(MessageBase message)
    {
        return message switch
        {
            FileMessage fileMessage => GenerateFileMessage(fileMessage, _helper.CombineByteArrays(
                    _helper.ObjectToByteArray(fileMessage.Data.Length), 
                    _helper.ObjectToByteArray(fileMessage.Data))),
            
            TextMessage textMessage => GenerateTextMessage(_helper.CombineByteArrays(
                _helper.ObjectToByteArray(textMessage.Data.Length), 
                _helper.ObjectToByteArray(textMessage.Data))),
            _ => throw new ArgumentException("Invalid message type")
        };
    }

    private IEnumerable<byte> GenerateTextMessage(IEnumerable<byte>sharedBytes)
    {
        return sharedBytes;
    }

    private IEnumerable<byte> GenerateFileMessage(FileMessage fileMessage, IEnumerable<byte>sharedBytes)
    {

        IEnumerable<byte> fileNameBytes = _helper.ObjectToByteArray(fileMessage.FileName);
        IEnumerable<byte> fileTypeBytes = _helper.ObjectToByteArray(fileMessage.FileType);
        IEnumerable<byte> dateOnlyBytes = _helper.ObjectToByteArray(fileMessage.DateOnly);
        var withUniqueFieldsBytes = sharedBytes.Concat(dateOnlyBytes).Concat(fileNameBytes).Concat(fileTypeBytes);
        return withUniqueFieldsBytes;
    }
}