namespace ChatProtocolRoyV2.GeneratorModule;

public class ChecksumByteArrayCalculator : IChecksumByteArrayCalculator
{
    public int CalculateChecksum(byte[] input){
        
        byte sum = 0;

        for(int i = 0; i < input.Length; i++)
        {
            sum ^= input[i];
        }
        return sum;
    }
    

}