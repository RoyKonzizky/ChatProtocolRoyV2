namespace ChatProtocolRoyV2.GeneratorModule;

public class ChecksumStringCalculator : IChecksumStringCalculator
{
    public int CalculateChecksum(string input){
        
        byte sum = 0;

        for(int i = 0; i < input.Length; i++)
        {
            sum ^= (byte)input[i];
        }
        return sum;
    }
}