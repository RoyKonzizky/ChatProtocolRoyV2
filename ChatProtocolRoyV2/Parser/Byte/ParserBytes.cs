using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Parser.Builder.Byte.Director;
using ChatProtocolRoyV2.Parser.Byte.Message.Types;
using ChatProtocolRoyV2.Parser.Byte.Message.Types.File;
using ChatProtocolRoyV2.Parser.Byte.Message.Types.Text;

namespace ChatProtocolRoyV2.Parser.Byte
{
    public class ParseBytes : IParseBytes
    {
        private readonly IDirector _director;
        private readonly ITextMessageParser _textMessageParser;
        private readonly IFileMessageParser _fileMessageParser;

        public ParseBytes(IDirector director, ITextMessageParser textMessageParser, IFileMessageParser fileMessageParser)
        {
            _director = director;
            _textMessageParser = textMessageParser;
            _fileMessageParser = fileMessageParser;
        }

        public MessageBase Parser(IEnumerable<byte> packetBytes)
        {
            var enumerable = packetBytes as byte[] ?? packetBytes.ToArray();
            var packetMessageBase = _director.Build(enumerable);

            var messageType = packetMessageBase.Type;
            return messageType switch
            {
                MessageType.TextMessage => _textMessageParser.Parser(packetMessageBase),
                MessageType.FileMessage => _fileMessageParser.Parser(packetMessageBase),
                _ => throw new Exception("Unknown message type")
            };
        }
    }
}

//TODO read about TryParse, yield 
//TODO read about Provider
//TODO finish the ctor