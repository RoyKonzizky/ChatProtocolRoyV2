namespace ChatProtocolRoyV2.Generator;

public interface IChecksumCalculator<in TInput>
{
    int CalculateChecksum(TInput input);
}