using System.Text;
using ChatProtocolRoyV2.DataModule;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Functionality;

public class Utilities
{
    /*public static byte CalculateChecksum(string data) {
        byte sum = 0;

        for(int i = 0; i < data.Length; i++)
        {
            sum ^= (byte)data[i];
        }
        return sum;
    }*/

    /*public MessageBase Parser(byte[] binaryMessage)
    {
        MessageBase message =  null!;
        byte sync = binaryMessage[0];

        byte[] idBytes = new byte[16];
        Array.Copy(binaryMessage, 1, idBytes, 0, 16);
        Guid id = new Guid(idBytes);

        byte[] dataBytes = new byte[binaryMessage.Length - 22];
        Array.Copy(binaryMessage, 17, dataBytes, 0, binaryMessage.Length - 22);
        string data = Encoding.ASCII.GetString(dataBytes);

        byte[] typeBytes = new byte[1];
        Array.Copy(binaryMessage, binaryMessage.Length - 4, typeBytes, 0, 1);
        MessageType typeOfMessage = (MessageType)Enum.Parse(typeof(MessageType), Encoding.ASCII.GetString(typeBytes));
        
        byte checkSum = binaryMessage[^3];

        byte tail = binaryMessage[^2];
        message = MessageFactory.CreateMessage(typeOfMessage, id, data);
        return message;
    }*/

    public byte[] ToBinaryArray(object message)
    {
        return null!;
    }
    
    public string DecodeStringFromBase64(string stringToDecode)
    {       
        return Encoding.UTF8.GetString(Convert.FromBase64String(stringToDecode));
    }
    public string EncodeStringToBase64(string stringToEncode)
    {
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(stringToEncode));
    }

}


/*use the Factory Method design pattern since the exact object is not clear immediately, maybe use builder(because of the different fields) instead
or use Visitor pattern*/
//might need to use the builder(and decorator maybe) for the generator module
/*also create a Packet class that inherits from MessageBase, it probably needs to use the builder in order to add
the needed aspect to the object, like making the checksum and type of file*/
//builder inherits from Message-base and each concrete builder from types of messages
//generic type-read about it
//generator module is supposed to generate the checksum in a specific class 