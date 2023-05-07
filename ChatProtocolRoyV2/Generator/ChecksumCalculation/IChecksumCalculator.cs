namespace ChatProtocolRoyV2.Generator.ChecksumCalculation;

public interface IChecksumCalculator<in TInput>
{
    int CalculateChecksum(TInput input);
}