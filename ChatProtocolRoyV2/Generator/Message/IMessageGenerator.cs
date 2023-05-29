using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Generator.Message;

public interface IMessageGenerator
{
    byte[] GenerateMessageBytes();
}