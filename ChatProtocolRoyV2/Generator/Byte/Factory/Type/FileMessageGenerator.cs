using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte.Factory.Type;

public class FileMessageGenerator
{
    private readonly IHelpBytes _helper;

    public FileMessageGenerator(IHelpBytes helper)
    {
        _helper = helper;
    }
    
    public IEnumerable<byte> GenerateFileMessage(FileMessage fileMessage, IEnumerable<byte> sharedBytes)
    {
        var fileNameBytes = _helper.ObjectToByteArray(fileMessage.FileName);
        var fileTypeBytes = _helper.ObjectToByteArray(fileMessage.FileType);
        var dateOnlyBytes = _helper.ObjectToByteArray(fileMessage.DateOnly);
        var withUniqueFieldsBytes = sharedBytes.Concat(dateOnlyBytes).Concat(fileNameBytes).Concat(fileTypeBytes);
        return withUniqueFieldsBytes;
    }
}