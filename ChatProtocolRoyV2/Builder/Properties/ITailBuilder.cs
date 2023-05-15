namespace ChatProtocolRoyV2.Builder.Properties;

public interface ITailBuilder : IBuilder<byte[], byte[]>
{
    ITailBuilder WithTail(byte[] tail);
}