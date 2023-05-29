using System;
using System.Collections.Generic;
using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte
{
    public class ByteGenerator : IByteGenerator
    {
        // TODO: design patterns can help writing a cleaner version of this code
        // TODO: implement factory method for all parts the messages share, and decorator for sync and checksum and tail
        // TODO: use constructor to not use the "new" keyword
        // TODO: give it an interface instead of class, i.e. instead of ChecksumByteArrayCalculator use IChecksumByteArrayCalculator

        private readonly IChecksumByteArrayCalculator _checksumCalculator;
        private readonly IHelpBytes _helper;

        public ByteGenerator(IChecksumByteArrayCalculator checksumCalculator, IHelpBytes helper)
        {
            _checksumCalculator = checksumCalculator ?? throw new ArgumentNullException(nameof(checksumCalculator));
            _helper = helper ?? throw new ArgumentNullException(nameof(helper));
        }

        public IEnumerable<byte> Generate(MessageBase messageBase)
        {
            var messageBytes = GenerateMessageBytes(messageBase);
            var checksumBytes = GenerateChecksumBytes(messageBytes);
            var syncBytes = _helper.ObjectToByteArray(MessageEdge.Sync);
            var tailBytes = _helper.ObjectToByteArray(MessageEdge.Tail);

            return _helper.CombineByteArrays(syncBytes, messageBytes, checksumBytes, tailBytes);
        }

        private byte[] GenerateMessageBytes(MessageBase messageBase)
        {
            switch (messageBase.Type)
            {
                case MessageType.FileMessage:
                    return GenerateFileMessageBytes((FileMessage)messageBase);

                case MessageType.TextMessage:
                    return GenerateTextMessageBytes((TextMessage)messageBase);

                default:
                    throw new Exception("Invalid message type");
            }
        }

        private byte[] GenerateFileMessageBytes(FileMessage fileMessage)
        {
            return _helper.CombineByteArrays(
                _helper.ObjectToByteArray(fileMessage.Id),
                _helper.ObjectToByteArray(fileMessage.Type),
                _helper.ObjectToByteArray(fileMessage.Data.Length),
                _helper.ObjectToByteArray(fileMessage.Data),
                _helper.ObjectToByteArray(fileMessage.FileType),
                _helper.ObjectToByteArray(fileMessage.DateOnly),
                _helper.ObjectToByteArray(fileMessage.FileName)
            );
        }

        private byte[] GenerateTextMessageBytes(TextMessage textMessage)
        {
            return _helper.CombineByteArrays(
                _helper.ObjectToByteArray(textMessage.Id),
                _helper.ObjectToByteArray(textMessage.Type),
                _helper.ObjectToByteArray(textMessage.Data.Length),
                _helper.ObjectToByteArray(textMessage.Data)
            );
        }

        private byte[] GenerateChecksumBytes(byte[] dataBytes)
        {
            var checksum = _checksumCalculator.CalculateChecksum(dataBytes);
            return _helper.ObjectToByteArray(checksum);
        }
    }
}
