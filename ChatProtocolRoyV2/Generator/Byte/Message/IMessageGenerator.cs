namespace ChatProtocolRoyV2.Generator.Byte.Message;

public interface IMessageGenerator
{
    //TODO IEnumerable instead of byte[]
    byte[] GenerateMessageBytes();
}