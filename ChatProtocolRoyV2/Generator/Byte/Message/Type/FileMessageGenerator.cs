using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte.Message.Type;

public class FileMessageGenerator : IMessageGenerator
{
    private readonly FileMessage _fileMessage;
    private readonly IHelpBytes _helper;

    public FileMessageGenerator(FileMessage fileMessage, IHelpBytes helper)
    {
        _fileMessage = fileMessage;
        _helper = helper;
    }

    public byte[] GenerateMessageBytes()
    {
        return _helper.CombineByteArrays(
            _helper.ObjectToByteArray(_fileMessage.Id),
            _helper.ObjectToByteArray(_fileMessage.Type),
            _helper.ObjectToByteArray(_fileMessage.Data.Length),
            _helper.ObjectToByteArray(_fileMessage.Data),
            _helper.ObjectToByteArray(_fileMessage.FileType),
            _helper.ObjectToByteArray(_fileMessage.DateOnly),
            _helper.ObjectToByteArray(_fileMessage.FileName)
        );
    }
}