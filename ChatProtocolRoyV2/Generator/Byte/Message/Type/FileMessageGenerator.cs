using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte.Message.Type;

public class FileMessageGenerator : IMessageGenerator
{
    private readonly IHelpBytes _helper;

    private FileMessageGenerator()
    {
        _helper = new HelpBytes();
    }

    public static FileMessageGenerator Instance { get; } = new();

    public IEnumerable<byte> Generate(MessageBase message)
    {
        if (message is not FileMessage fileMessage)
            throw new ArgumentException("Invalid message type");

        return _helper.CombineByteArrays(
            _helper.ObjectToByteArray(fileMessage.Data.Length),
            _helper.ObjectToByteArray(fileMessage.Data),
            _helper.ObjectToByteArray(fileMessage.DateOnly),
            _helper.ObjectToByteArray(fileMessage.FileName),
            _helper.ObjectToByteArray(fileMessage.FileType)
        );
    }
}
//TODO use a factory to reduce to duplication