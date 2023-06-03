using ChatProtocolRoyV2.Data;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator.Byte.Message;

namespace ChatProtocolRoyV2.Generator.Byte.Provider
{
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
}

//TODO the provider(called factory but implemented as a provider) will receive generators and decide what to return based on the input
