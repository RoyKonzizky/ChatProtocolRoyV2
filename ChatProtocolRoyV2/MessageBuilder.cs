using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2
{
    public class MessageBuilder
    {
        private readonly MessageType _type;
        private readonly Guid _guid;
        private string _text = null!;
        private string _fileName = null!;
        private string _fileContent = null!;

        public MessageBuilder(MessageType type, Guid guid)
        {
            _type = type;
            _guid = guid;
        }

        public MessageBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public MessageBuilder WithFile(string fileName, string fileContent)
        {
            _fileName = fileName;
            _fileContent = fileContent;
            return this;
        }

        public MessageBase Build()
        {
            return _type switch
            {
                MessageType.Audio => new Audio(_guid, _type),
                MessageType.Image => new Image(_guid, _type),
                MessageType.TextMessage => new TextMessage(_guid, _type, _text),
                MessageType.FileMessage => new FileMessage(_guid, _type, _fileName, _fileContent),
                _ => throw new ArgumentException("Invalid message type.")
            };
        }
    }
}