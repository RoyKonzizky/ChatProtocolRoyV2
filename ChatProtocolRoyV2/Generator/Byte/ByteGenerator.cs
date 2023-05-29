using ChatProtocolRoyV2.ChecksumCalculator.Byte;
using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper;

namespace ChatProtocolRoyV2.Generator.Byte;

public class ByteGenerator : IByteGenerator
{
    //TODO design patterns can help writing a cleaner version of this code
    public IEnumerable<byte> Generate(MessageBase messageBase)
    {
        var calculator = new ChecksumByteArrayCalculator();
        var helper = new Help();

        switch (messageBase.Type)
        {
            case MessageType.FileMessage:
            {
                var fileMessage = (FileMessage)messageBase;
                
                return helper.CombineByteArrays(helper.ObjectToByteArray(MessageEdge.Sync),
                    helper.ObjectToByteArray(messageBase.Id), helper.ObjectToByteArray(messageBase.Type),
                    helper.ObjectToByteArray(fileMessage.Data.Length), helper.ObjectToByteArray(fileMessage.Data),
                    helper.ObjectToByteArray(fileMessage.FileType), helper.ObjectToByteArray(fileMessage.DateOnly), helper.ObjectToByteArray(fileMessage.FileName),
                    helper.ObjectToByteArray(calculator.CalculateChecksum(helper.ObjectToByteArray(fileMessage.Data))),
                    helper.ObjectToByteArray(MessageEdge.Tail));
            }

            case MessageType.TextMessage:
            {
                var textMessage = (TextMessage)messageBase;

                return helper.CombineByteArrays(helper.ObjectToByteArray(MessageEdge.Sync),
                    helper.ObjectToByteArray(messageBase.Id), helper.ObjectToByteArray(messageBase.Type),
                    helper.ObjectToByteArray(textMessage.Data.Length), helper.ObjectToByteArray(textMessage.Data),
                    helper.ObjectToByteArray(calculator.CalculateChecksum(helper.ObjectToByteArray(textMessage.Data))),
                    helper.ObjectToByteArray(MessageEdge.Tail));
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