using ChatProtocolRoyV2.DataModule;
using ChatProtocolRoyV2.DataModule.Types;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Factories;

public static class MessageFactory
{
    public static MessageBase CreateMessage(MessageType type, Guid guid, params object[]args)
    {
        switch (type)
        {
            case MessageType.TextMessage:
                return new TextMessage(guid, type, (string)args[0]);
            case MessageType.Audio:
                return new Audio(guid, type);
            case MessageType.Image:
                return new Image(guid, type);
            case MessageType.FileMessage:
                return new FileMessage(guid, type, (string)args[0],(string)args[1]);
            default:
                throw new ArgumentException("Invalid message type.");
        }
    }
}
