namespace ChatProtocolRoyV2.Generator.ChecksumCalculation.Types;

public class ChecksumByteArrayCalculator : IChecksumByteArrayCalculator
{
    public uint CalculateChecksum(byte[] input){
        int length = input.Length;
        int i = 0;

        uint sum = 0;
        while (length > 1)
        {
            sum += (ushort)(input[i++] << 8 | input[i++]);
            length -= 2;
        }

        if (length > 0)
        {
            sum += (ushort)(input[i] << 8);
        }

        while (sum >> 16 != 0)
        {
            sum = (sum & 0xFFFF) + (sum >> 16);
        }

        return ~sum;
    }

    public uint CalculateChecksum(IEnumerable<byte> input)
    {
        throw new NotImplementedException();
    }
}