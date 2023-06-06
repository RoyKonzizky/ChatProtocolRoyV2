using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Generator.Byte.Factory.Type;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte.Factory;

public class MessageGeneratorByteFactory
{
    private readonly IHelpBytes _helper;
    private readonly FileMessageGenerator _fileMessageGenerator;
    private readonly TextMessageGenerator _textMessageGenerator;

    public MessageGeneratorByteFactory(IHelpBytes helper, 
        FileMessageGenerator fileMessageGenerator, TextMessageGenerator textMessageGenerator)
    {
        _helper = helper;
        _fileMessageGenerator = fileMessageGenerator;
        _textMessageGenerator = textMessageGenerator;
    }

    public IEnumerable<byte> Generate(MessageBase message)
    {
        return message switch
        {
            FileMessage fileMessage => _fileMessageGenerator.GenerateFileMessage(fileMessage, 
                _helper.ObjectToByteArray(fileMessage.Data.Length).Concat(_helper.ObjectToByteArray(fileMessage.Data))),

            TextMessage textMessage => _textMessageGenerator.GenerateTextMessage(
                _helper.ObjectToByteArray(textMessage.Data.Length).Concat(_helper.ObjectToByteArray(textMessage.Data))),
            
            _ => throw new ArgumentException("Invalid message type")
        };
    }
}