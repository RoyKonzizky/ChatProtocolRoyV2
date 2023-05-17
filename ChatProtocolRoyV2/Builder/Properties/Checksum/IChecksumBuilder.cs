namespace ChatProtocolRoyV2.Builder.Properties.Checksum;

public interface IChecksumBuilder : IBuilder<byte[], uint>
{
    IChecksumBuilder WithChecksum(byte[] array);
}