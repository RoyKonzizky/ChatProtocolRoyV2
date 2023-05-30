using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Generator.Byte.Message;
using ChatProtocolRoyV2.Generator.Byte.Message.Type;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Generator.Byte.Factory;

public class MessageGeneratorFactory : IMessageGeneratorFactory
{
    public IMessageGenerator CreateMessageGenerator(MessageBase messageBase)
    {
        return messageBase.Type switch
        {
            MessageType.TextMessage => TextMessageGenerator.Instance,
            MessageType.FileMessage => FileMessageGenerator.Instance,
            _ => throw new ArgumentException("Invalid file message type")
        };
    }

}