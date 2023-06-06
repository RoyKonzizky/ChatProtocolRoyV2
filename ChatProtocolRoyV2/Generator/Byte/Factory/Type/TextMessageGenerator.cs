namespace ChatProtocolRoyV2.Generator.Byte.Factory.Type;

public class TextMessageGenerator
{
    public IEnumerable<byte> GenerateTextMessage(IEnumerable<byte> sharedBytes)
    {
        return sharedBytes;
    }
}