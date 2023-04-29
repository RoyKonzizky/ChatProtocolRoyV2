using System.Collections;
using System.Text;

namespace ChatProtocolRoyV2;

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

    public ArrayList Parser(byte[] binaryPackage, byte sync, byte tail,string data, byte checkSum, string fileType, Guid id)
    {
        ArrayList arrayList = new ArrayList();
        
        sync = binaryPackage[0];

        byte[] idBytes = new byte[16];
        Array.Copy(binaryPackage, 1, idBytes, 0, 16);
        id = new Guid(idBytes);

        byte[] dataBytes = new byte[binaryPackage.Length - 22];
        Array.Copy(binaryPackage, 17, dataBytes, 0, binaryPackage.Length - 22);
        data = Encoding.ASCII.GetString(dataBytes);

        byte[] typeBytes = new byte[1];
        Array.Copy(binaryPackage, binaryPackage.Length - 4, typeBytes, 0, 1);
        fileType = Encoding.ASCII.GetString(typeBytes);

        checkSum = binaryPackage[binaryPackage.Length - 3];

        tail = binaryPackage[binaryPackage.Length - 2];
        
        arrayList.Add(sync);
        arrayList.Add(tail);
        arrayList.Add(data);
        arrayList.Add(checkSum);
        arrayList.Add(fileType);
        arrayList.Add(id);

        return arrayList;
    }

    public byte TurnToBinaryPackage()
    {
        byte binaryPackage = 0;
        
        return binaryPackage;
    }
}