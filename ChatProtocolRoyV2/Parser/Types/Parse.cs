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
        //TODO: rework the parser class according to the following principle: since te packet has T Data property, it receives a messageBase object, so in order to get specific parts of each object(i.e. the fileName and dateOfCreation i need to take it apart by it's fields(probably by size)

        byte sync = input[0];

        byte[] idBytes = new byte[16];
        Array.Copy(input, 1, idBytes, 0, 16);
        Guid id = new Guid(idBytes);

        byte[] dataBytes = new byte[input.Length - 22];
        Array.Copy(input, 17, dataBytes, 0, input.Length - 22);
        string data = Encoding.ASCII.GetString(dataBytes);
    
        byte[] typeBytes = new byte[1];
        Array.Copy(input, input.Length - 4, typeBytes, 0, 1);
        MessageType typeOfMessage = (MessageType) Enum.Parse(typeof(MessageType), Encoding.ASCII.GetString(typeBytes));
    
        byte checkSumBytes = input[^3];
        int checkSum = Convert.ToInt32(checkSumBytes);
            
        byte tail = input[^2];

        MessageBuilder builder = new MessageBuilder(typeOfMessage, id);

        switch (typeOfMessage)
        {
            case MessageType.FileMessage:
            {
                FileTypeFinder fileTypeFinder = new FileTypeFinder();
                HeaderBytesCalculator headerBytesCalculator = new HeaderBytesCalculator();
                byte[] headerBytes = headerBytesCalculator.GetHeaderBytes(dataBytes);
                string typeOfFile = fileTypeFinder.FindFileType(headerBytes);
                builder.WithFile(nameOfFile, data, dateOfFileCreation, typeOfFile);
                break;
            }

            case MessageType.TextMessage:
                builder.WithText(data);
                break;

            case MessageType.Audio:
                break;
            case MessageType.Image:
                break;

            default:
                throw new ArgumentException("Invalid message type.");
        }

        MessageBase message = builder.Build();

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