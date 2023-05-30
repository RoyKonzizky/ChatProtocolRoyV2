using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte.Message.Type;

public class TextMessageGenerator : IMessageGenerator
{
    private readonly TextMessage _textMessage;
    private readonly IHelpBytes _helper;

    public TextMessageGenerator(TextMessage textMessage, IHelpBytes helper)
    {
        _textMessage = textMessage;
        _helper = helper;
    }

    public byte[] GenerateMessageBytes()
    {
        return _helper.CombineByteArrays(
            _helper.ObjectToByteArray(_textMessage.Id),
            _helper.ObjectToByteArray(_textMessage.Type),
            _helper.ObjectToByteArray(_textMessage.Data.Length),
            _helper.ObjectToByteArray(_textMessage.Data)
        );
    }
}