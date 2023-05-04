using System.Collections;
using System.Text;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Utilities;

namespace ChatProtocolRoyV2.Parser.Types;

public class Parse : IParseBytes
{
    public ArrayList Parser(byte[] input)
    {
        MessageBase message =  null!;
        object[] args = new object[2];
        
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
                break;
            }

            case MessageType.TextMessage:
                args[0] = data;
                break;

            case MessageType.Audio:
            case MessageType.Image:
                break;
                
            default:
                throw new ArgumentException("Invalid message type.");
        }
        
        message = MessageFactory.CreateMessage(typeOfMessage, id, args);

        ArrayList arrayList = new ArrayList
        {
            message,
            checkSum,
            sync,
            tail
        };

        return arrayList;
    }
    
}