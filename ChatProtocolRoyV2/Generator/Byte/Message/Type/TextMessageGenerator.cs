using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Data.Types;
using ChatProtocolRoyV2.Helper.Byte;

namespace ChatProtocolRoyV2.Generator.Byte.Message.Type;

public class TextMessageGenerator : IMessageGenerator
{
    private readonly IHelpBytes _helper;

    private TextMessageGenerator()
    {
        _helper = new HelpBytes();
    }

    public static TextMessageGenerator Instance { get; } = new();

    public IEnumerable<byte> Generate(MessageBase message)
    {
        if (message is not TextMessage textMessage)
            throw new ArgumentException("Invalid message type");

        return _helper.CombineByteArrays(
            _helper.ObjectToByteArray(textMessage.Data.Length),
            _helper.ObjectToByteArray(textMessage.Data)
        );
    }
    //TODO change to factory method to prevent duplication-not factory but no duplication
}