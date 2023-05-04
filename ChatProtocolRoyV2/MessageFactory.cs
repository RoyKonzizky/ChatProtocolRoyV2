using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2;

public static class MessageFactory
{
    public static MessageBase CreateMessage(MessageType type, Guid guid, params object[]args)
    {
        switch (type)
        {
            case MessageType.Audio:
                return new Audio(guid, type);
            
            case MessageType.Image:
                return new Image(guid, type);
            
            case MessageType.TextMessage:
                return new TextMessage(guid, type, (string)args[0]);
            
            case MessageType.FileMessage:
                return new FileMessage(guid, type, (string)args[0],(string)args[1]);
            
            default:
                throw new ArgumentException("Invalid message type.");
        }
    }
    //TODO: replace params object[]args with a different solution or write the builder pattern
}
