namespace ChatProtocolRoyV2.Builder.Properties;

public interface IChecksumBuilder : IBuilder<uint, byte[]>
{
    IChecksumBuilder WithChecksum(byte[] data);
}