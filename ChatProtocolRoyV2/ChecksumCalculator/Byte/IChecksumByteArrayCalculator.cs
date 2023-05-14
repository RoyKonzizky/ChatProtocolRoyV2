using ChatProtocolRoyV2.ChecksumCalculator;

namespace ChatProtocolRoyV2.Generator.Byte;

public interface IChecksumByteArrayCalculator : IChecksumCalculator<IEnumerable<byte>>
{
}