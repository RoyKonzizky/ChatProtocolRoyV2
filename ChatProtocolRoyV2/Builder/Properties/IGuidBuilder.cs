namespace ChatProtocolRoyV2.Builder.Properties;

public interface IGuidBuilder : IBuilder<Guid, byte[]>
{
    IGuidBuilder WithGuid(byte[] guidBytes);
}