namespace ChatProtocolRoyV2.ChecksumCalculator.Byte;

public class ChecksumByteArrayCalculator : IChecksumByteArrayCalculator
{
    public uint CalculateChecksum(IEnumerable<byte> input)
    {
        uint sum = 0;
        foreach (byte b in input)
        {
            sum += b;
        }

        return sum;
    }
}