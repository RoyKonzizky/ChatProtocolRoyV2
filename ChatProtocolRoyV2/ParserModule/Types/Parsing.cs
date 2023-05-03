using System.Text;
using ChatProtocolRoyV2.DataModule;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Factories;
using ChatProtocolRoyV2.ParserModule.Utilities;

namespace ChatProtocolRoyV2.ParserModule.Types;

public class Parsing : IParsingBytes
{
    public MessageBase Parser(byte[] input)
    {
        MessageBase message =  null!;
        object[] args = new object[]{ };
        
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
                FileTypeFinder fileTypeFinder = new FileTypeFinder();
                HeaderBytesCalculator headerBytesCalculator = new HeaderBytesCalculator();
                byte[] headerBytes = headerBytesCalculator.GetHeaderBytes(dataBytes);
                string typeOfFile = fileTypeFinder.FindFileType(headerBytes);
                args[0] = data;
                args[1] = typeOfFile;
                message = MessageFactory.CreateMessage(typeOfMessage, id, args);
                break;
            }
            
            case MessageType.TextMessage:
                args[0] = data;
                message = MessageFactory.CreateMessage(typeOfMessage, id, args);
                break;
            
            case MessageType.Audio:
                message = MessageFactory.CreateMessage(typeOfMessage, id);
                break;
            
            case MessageType.Image:
                message = MessageFactory.CreateMessage(typeOfMessage, id);
                break;
        }
        return message;
    }
}