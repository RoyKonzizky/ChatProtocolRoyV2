namespace ChatProtocolRoyV2.Helper.Byte;

public interface IHelpBytes : IHelp
{
    byte[] ObjectToByteArray<T>(T obj);
    T FromByteArray<T>(byte[] byteArray);
    IEnumerable<byte> CombineByteArrays(params byte[][] arrays);
}
//TODO IEnumerable instead of byte[]
//TODO remove params by using built in methods in IEnumerable