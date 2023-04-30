using System.Text;

namespace ChatProtocolRoyV2.Functionality;

public class Utilities
{
    public static byte CalculateChecksum(string data) {
        byte sum = 0;

        for(int i = 0; i < data.Length; i++)
        {
            sum ^= (byte)data[i];
        }
        return sum;
    }

    public TArrayList Parser<TArrayList>(byte[] binaryPackage, bool isFile) where TArrayList : new()
    {
        TArrayList arrayListOfObjectFields = new TArrayList();
        
        byte sync = binaryPackage[0];

        byte[] idBytes = new byte[16];
        Array.Copy(binaryPackage, 1, idBytes, 0, 16);
        Guid id = new Guid(idBytes);

        byte[] dataBytes = new byte[binaryPackage.Length - 22];
        Array.Copy(binaryPackage, 17, dataBytes, 0, binaryPackage.Length - 22);
        string data = Encoding.ASCII.GetString(dataBytes);

        byte[] typeBytes = new byte[1];
        Array.Copy(binaryPackage, binaryPackage.Length - 4, typeBytes, 0, 1);
        string fileType = Encoding.ASCII.GetString(typeBytes);

        byte checkSum = binaryPackage[^3];

        byte tail = binaryPackage[^2];
        
        arrayListOfObjectFields.Add(sync);
        arrayListOfObjectFields.Add(tail);
        arrayListOfObjectFields.Add(data);
        arrayListOfObjectFields.Add(checkSum);
        arrayListOfObjectFields.Add(fileType);
        arrayListOfObjectFields.Add(id);

        return arrayListOfObjectFields;
    }

    public byte[] ToBinaryArray(object message)
    {
        return null;
    }
}

//instead of message class use the MessageBase and use it on the parser
//use interface so the parser will decide what type of message is being parsed
//use the Factory Method design pattern since the exact object is not clear immediately
//decide how to use the interface and abstract class i have according to the FactoryMethodV2 proj or use Visitor pattern
//need to re-think how the checksum works as it only belongs in the packet, not as a field or property
//might need to use the builder(and decorator maybe) for the generator module
/*also create a Packet class that inherits from MessageBase, it probably needs to use the builder in order to add
the needed aspect to the object, like making the checksum and type of file*/
//builder inherits from Messagebase and each concrete builder from types of messages
