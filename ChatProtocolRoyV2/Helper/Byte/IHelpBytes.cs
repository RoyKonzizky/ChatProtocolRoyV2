namespace ChatProtocolRoyV2.Helper.Byte;

public interface IHelpBytes : IHelp
{
    IEnumerable<byte> ObjectToByteArray<T>(T obj);
    T FromByteArray<T>(IEnumerable<byte> byteArray);
    IEnumerable<byte> CombineByteArrays(IEnumerable<byte[]> arrays);
}
//TODO IEnumerable instead of byte[]
//TODO remove params by using built in methods in IEnumerable