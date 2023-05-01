using System.Runtime.Serialization.Formatters.Binary;
using ChatProtocolRoyV2.DataModule;

namespace ChatProtocolRoyV2;

public class BinaryArrayCreator
{
    public static byte[] ToBinaryArray(MessageBase messageBase)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        using MemoryStream stream = new MemoryStream();
        formatter.Serialize(stream, messageBase);
        return stream.ToArray();
    }
    
}