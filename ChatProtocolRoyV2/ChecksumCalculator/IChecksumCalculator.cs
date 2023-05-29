namespace ChatProtocolRoyV2.ChecksumCalculator;

public interface IChecksumCalculator<in TInput>
{
    uint CalculateChecksum(TInput input);
}
