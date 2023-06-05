using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator.Byte.Message;

namespace ChatProtocolRoyV2.Generator.Byte.Provider;

public class MessageGeneratorProvider : IMessageGeneratorProvider
{
    private readonly IDictionary<MessageType, IMessageGenerator> _generatorDictionary;

    public MessageGeneratorProvider(IDictionary<MessageType, IMessageGenerator> generatorDictionary)
    {
        _generatorDictionary = generatorDictionary ?? throw new ArgumentNullException(nameof(generatorDictionary));
    }

    public IMessageGenerator Generate(MessageBase messageBase)
    {
        if (!_generatorDictionary.TryGetValue(messageBase.Type, out var generator))
            throw new ArgumentException("Invalid message type");

        return generator;
    }
}
//TODO in the upper levels its not good to have to give it a dictionary to initialize as they shouldn't be expected to be familiar with the small details of the protocol,
//TODO its better to just give the provider to provide and for it to return just the generator and not use a dictionary 