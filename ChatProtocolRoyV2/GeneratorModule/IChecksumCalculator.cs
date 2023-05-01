namespace ChatProtocolRoyV2.GeneratorModule;

public interface IChecksumCalculator<in TInput>
{
    int CalculateChecksum(TInput input);
    
}