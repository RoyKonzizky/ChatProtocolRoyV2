using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Data.Types.Files;
using ChatProtocolRoyV2.Entities;
using System;

namespace ChatProtocolRoyV2
{
    public class MessageBuilder
    {
        private MessageType _type;
        private Guid _guid;
        private string _text;
        private string _fileName;
        private string _fileContent;
        private string _fileType;
        private DateOnly _dateOnly;

        public MessageBuilder WithType(MessageType type)
        {
            _type = type;
            return this;
        }

        public MessageBuilder WithGuid(Guid guid)
        {
            _guid = guid;
            return this;
        }

        public MessageBuilder WithText(string text)
        {
            _text = text;
            return this;
        }

        public MessageBuilder WithFile(string fileName, string fileContent, DateOnly dateOnly, string fileType)
        {
            _fileName = fileName;
            _fileContent = fileContent;
            _dateOnly = dateOnly;
            _fileType = fileType;
            return this;
        }

        public MessageBase Build()
        {
            switch (_type)
            {
                case MessageType.TextMessage:
                    return new TextMessage(_guid, _text);
                case MessageType.FileMessage:
                    return new FileMessage(_guid, _type, _dateOnly, _fileName, _fileContent, _fileType);
                default:
                    throw new ArgumentException("Invalid message type.");
            }
        }
    }
}