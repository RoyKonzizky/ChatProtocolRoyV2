using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Generator.Byte.Message;

public interface IMessageGenerator
{
    IEnumerable<byte> GenerateMessageBytes(MessageBase messageBase);
}