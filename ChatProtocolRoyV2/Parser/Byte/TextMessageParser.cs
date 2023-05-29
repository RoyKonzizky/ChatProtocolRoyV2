using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;

namespace ChatProtocolRoyV2.Parser.Byte
{
    public class TextMessageParser
    {
        public TextMessage Parse(MessageBase messageBase)
        {
            if (messageBase is not TextMessage textMessage)
                throw new ArgumentException("Invalid message type");

            var message = new TextMessage(textMessage.Id, textMessage.Data);

            return message;
        }
    }
}
