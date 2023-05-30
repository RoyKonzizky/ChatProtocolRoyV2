using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Data.Types.Files;
using ChatProtocolRoyV2.Entities;

namespace ChatProtocolRoyV2.Parser.Byte.Message.Types.File;

public class FileMessageParser : IFileMessageParser
{
    public FileMessage Parser(MessageBase messageBase)
    {
        if (messageBase is not FileMessage fileMessage)
            throw new ArgumentException("Invalid message type");

        return fileMessage.FileType switch
        {
            FileTypes.Image => ParseImageMessage(fileMessage),
            FileTypes.Audio => ParseAudioMessage(fileMessage),
            _ => throw new ArgumentException("Unknown file type")
        };
    }

    private Image ParseImageMessage(FileMessage fileMessage)
    {
        if (fileMessage is not Image imageFileMessage)
            throw new ArgumentException("Invalid message type");

        var imageMessage = new Image(imageFileMessage.Id, imageFileMessage.Data, imageFileMessage.DateOnly,
            imageFileMessage.FileName);

        return imageMessage;
    }

    private Audio ParseAudioMessage(FileMessage fileMessage)
    {
        if (fileMessage is not Audio audioFileMessage)
            throw new ArgumentException("Invalid message type");

        var audioMessage = new Audio(audioFileMessage.Id, audioFileMessage.Data, audioFileMessage.DateOnly,
            audioFileMessage.FileName);

        return audioMessage;
    }
}