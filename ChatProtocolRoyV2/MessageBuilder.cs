using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Data.Types.Files;
using ChatProtocolRoyV2.Entities;
using System;

namespace ChatProtocolRoyV2
{
    public class MessageBuilder
    {
        private object _type = null!;
        private Guid _guid;
        private string _text = null!;
        private string _fileName = null!;
        private string _fileContent = null!;
        private string _fileType = null!;
        private DateOnly _dateOnly;

        public MessageBuilder WithType(object type)
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
            return _type switch
            {
                MessageType.TextMessage => new TextMessage(_guid, _text),
                MessageType.FileMessage => new FileMessage(_guid, _type, _dateOnly, _fileName, _fileContent, _fileType),
                FileTypes.Audio => new Audio(_guid, _dateOnly, _fileName, _fileContent, _fileType),
                FileTypes.Image => new Image(_guid, _dateOnly, _fileName, _fileContent, _fileType),
                _ => throw new ArgumentException("Invalid message type.")
            };
        }
    }
}