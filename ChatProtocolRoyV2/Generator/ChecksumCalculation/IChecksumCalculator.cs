namespace ChatProtocolRoyV2.Generator.ChecksumCalculation;

public interface IChecksumCalculator<in TInput>
{
    uint CalculateChecksum(TInput input);
}
//TODO add startindex and endindex