using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Message;

public interface IMessageBuilder<in T> : IBuilder<T, MessageBase>
{
}