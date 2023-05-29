using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Generator.Message;
using ChatProtocolRoyV2.Generator.Message.Type;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Factory;

public class MessageGeneratorFactory : IMessageGeneratorFactory
{
    private readonly IHelpBytes _helper;

    public MessageGeneratorFactory(IHelpBytes helper)
    {
        _helper = helper;
    }

    public IMessageGenerator CreateMessageGenerator(MessageBase messageBase)
    {
        return messageBase switch
        {
            null => throw new ArgumentNullException(nameof(messageBase)),
            FileMessage fileMessage => new FileMessageGenerator(fileMessage, _helper),
            TextMessage textMessage => new TextMessageGenerator(textMessage, _helper),
            _ => throw new ArgumentException("Invalid message type")
        };
    }
}