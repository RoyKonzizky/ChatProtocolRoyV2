using System.Text;
using ChatProtocolRoyV2.DataModule;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Factories;

namespace ChatProtocolRoyV2.ParserModule;

public class Parsing : IParsingBytes
{
    public MessageBase Parser(byte[] input)
    {
        MessageBase message =  null!;
        byte sync = input[0];

        byte[] idBytes = new byte[16];
        Array.Copy(input, 1, idBytes, 0, 16);
        Guid id = new Guid(idBytes);

        byte[] dataBytes = new byte[input.Length - 22];
        Array.Copy(input, 17, dataBytes, 0, input.Length - 22);
        string data = Encoding.ASCII.GetString(dataBytes);

        byte[] typeBytes = new byte[1];
        Array.Copy(input, input.Length - 4, typeBytes, 0, 1);
        MessageType typeOfMessage = (MessageType)Enum.Parse(typeof(MessageType), Encoding.ASCII.GetString(typeBytes));
        
        byte checkSum = input[^3];

        byte tail = input[^2];
        switch (typeOfMessage)
        {
            case MessageType.FileMessage:
            {
                object[] args = new object[] { };
                FileTypeFinder fileTypeFinder = new FileTypeFinder();
                HeaderBytesCalculator headerBytesCalculator = new HeaderBytesCalculator();
                byte[] headerBytes = headerBytesCalculator.GetHeaderBytes(dataBytes);
                string typeOfFile = fileTypeFinder.FindFileType(headerBytes);
                args[0] = typeOfFile;
                args[1] = 
                message = MessageFactory.CreateMessage(typeOfMessage, id, data);
                break;
            }
            case MessageType.TextMessage:
                
                
                message = MessageFactory.CreateMessage(typeOfMessage, id, data);
                break;
            case MessageType.Audio:
                
                
                message = MessageFactory.CreateMessage(typeOfMessage, id, data);
                break;
            case MessageType.Image:
                
                
                message = MessageFactory.CreateMessage(typeOfMessage, id, data);
                break;
            default:
                break;
        }
        return message;
    }
    //TODO rewrite this section so it would correctly parse each message type
}