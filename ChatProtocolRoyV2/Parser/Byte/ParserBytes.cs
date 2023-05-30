using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Parser.Builder.Byte.Director;
using ChatProtocolRoyV2.Parser.Byte.Message.Types;

namespace ChatProtocolRoyV2.Parser.Byte
{
    public class ParseBytes : IParseBytes
    {
        private readonly IDirector _director;
        public ParseBytes(IDirector director)
        {
            _director = director;
            
        }

        public MessageBase Parser(IEnumerable<byte> packetBytes)
        {
            var enumerable = packetBytes as byte[] ?? packetBytes.ToArray();
            var packetMessageBase = _director.Build(enumerable);

            var messageType = packetMessageBase.Type;
            switch (messageType)
            {
                case MessageType.TextMessage:
                    var textMessageParser = new TextMessageParser();
                    return textMessageParser.Parse(packetMessageBase);
                case MessageType.FileMessage:
                    var fileMessageParser = new FileMessageParser();
                    return fileMessageParser.Parse(packetMessageBase);
                default:
                    throw new Exception("Unknown message type");
            }
        }
    }
}

//TODO read about TryParse, yield 
//TODO read about Provider
//TODO finish the ctor