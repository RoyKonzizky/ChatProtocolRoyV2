using System.Net.Mime;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;
using File = System.IO.File;

namespace ChatProtocolRoyV2.Functionality;

public static class MessageFactory
{
    public static MessageBase CreateMessage(MessageType type, Guid guid, params object[] args)
    {
        switch (type)
        {
            case MessageType.Text:
                if (args.Length != 1 || !(args[0] is string)) 
                    throw new ArgumentException("Invalid arguments for TextMessage.");
                return new TextMessage(guid, type, (string)args[0]);
            case MessageType.Audio:
                return new Audio(guid, type);
            case MessageType.Image:
                return new Image(guid, type);
            case MessageType.File:
                if (args.Length != 2 || !(args[0] is string) || !(args[1] is string))
                    throw new ArgumentException("Invalid arguments for File.");
                return new File(guid, type, (string)args[0], (string)args[1]);
            default:
                throw new ArgumentException("Invalid message type.");
        }
    }
}
