namespace ChatProtocolRoyV2.ParserModule.Utilities;

public class HeaderBytesCalculator
{
    public byte[] GetHeaderBytes(byte[]entireByteArray)
    {
        BinaryReader reader = new BinaryReader(new MemoryStream(entireByteArray));
        byte[] headerBytes = reader.ReadBytes(16);
        return headerBytes;
    }
}