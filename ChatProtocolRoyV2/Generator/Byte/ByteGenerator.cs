using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper;

namespace ChatProtocolRoyV2.Generator.Byte;

public class ByteGenerator : IByteGenerator
{
    //TODO maybe write methods to clean the methods as it does multiple things
    public IEnumerable<byte> Generate(MessageBase messageBase)
    {
        var sync = MessageEdge.Sync;
        var id = messageBase.Id;
        var type = messageBase.Type;

        int dataLength;
        string data;
        uint checksum;
        var tail = MessageEdge.Tail;

        var calculator = new ChecksumByteArrayCalculator();
        var helper = new Help();
        byte[] completeByteArray;

        switch (type)
        {
            case MessageType.FileMessage:
            {
                var fileMessage = (FileMessage)messageBase;
                var fileType = fileMessage.FileType;
                var dateOnly = fileMessage.DateOnly;
                var fileName = fileMessage.FileName;

                data = fileMessage.Data;
                dataLength = data.Length;
                checksum = calculator.CalculateChecksum(helper.ObjectToByteArray(data));

                completeByteArray = helper.CombineByteArrays(helper.ObjectToByteArray(sync),
                    helper.ObjectToByteArray(id), helper.ObjectToByteArray(type),
                    helper.ObjectToByteArray(dataLength), helper.ObjectToByteArray(data),
                    helper.ObjectToByteArray(fileType), helper.ObjectToByteArray(dateOnly),
                    helper.ObjectToByteArray(fileName),
                    helper.ObjectToByteArray(checksum),
                    helper.ObjectToByteArray(tail));

                return completeByteArray;
            }

            case MessageType.TextMessage:
            {
                var textMessage = (TextMessage)messageBase;
                data = textMessage.Data;
                dataLength = data.Length;
                checksum = calculator.CalculateChecksum(helper.ObjectToByteArray(data));

                completeByteArray = helper.CombineByteArrays(helper.ObjectToByteArray(sync),
                    helper.ObjectToByteArray(id), helper.ObjectToByteArray(type),
                    helper.ObjectToByteArray(dataLength), helper.ObjectToByteArray(data),
                    helper.ObjectToByteArray(checksum),
                    helper.ObjectToByteArray(tail));

                return completeByteArray;
            }

            default:
            {
                throw new Exception("Invalid type");
            }
        }
    }
}

//why IEnumerable better-more flexible as it can return more specific types when needed in certain cases without breaking the footprint(Memory footprint refers to the amount of main memory that a program uses or references while running) of the method)
//This class's purpose is to take one type and translate it to a different one. if parser translate byte[]arr into message/packet, this class should convert packet into byte[]arr