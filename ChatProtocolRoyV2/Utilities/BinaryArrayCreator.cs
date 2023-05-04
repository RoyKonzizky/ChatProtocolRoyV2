using System.Text;
using System.Text.Json;
using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Utilities;

public class BinaryArrayCreator
{
    public static byte[] ToBinaryArray(MessageBase messageBase)
    { 
        string jsonString = JsonSerializer.Serialize(messageBase);
        byte[] byteArray = Encoding.UTF8.GetBytes(jsonString);
        return byteArray;
    }
    
}