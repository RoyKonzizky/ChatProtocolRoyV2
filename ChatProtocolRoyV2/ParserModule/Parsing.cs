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
        message = MessageFactory.CreateMessage(typeOfMessage, id, data);
        return message;
    }
}