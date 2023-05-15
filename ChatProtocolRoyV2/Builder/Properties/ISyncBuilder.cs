namespace ChatProtocolRoyV2.Builder.Properties;

public interface ISyncBuilder : IBuilder<byte[], byte[]>
{
    ISyncBuilder WithSync(byte[] sync);
}