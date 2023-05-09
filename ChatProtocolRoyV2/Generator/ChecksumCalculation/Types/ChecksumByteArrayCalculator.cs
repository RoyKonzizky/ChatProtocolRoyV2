namespace ChatProtocolRoyV2.Generator.ChecksumCalculation.Types;

public class ChecksumByteArrayCalculator : IChecksumByteArrayCalculator
{

    public uint CalculateChecksum(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();
        int length = enumerable.Length;
        int i = 0;

        uint sum = 0;
        while (length > 1)
        {
            sum += (ushort)(enumerable[i++] << 8 | enumerable[i++]);
            length -= 2;
        }

        if (length > 0)
        {
            sum += (ushort)(enumerable[i] << 8);
        }

        while (sum >> 16 != 0)
        {
            sum = (sum & 0xFFFF) + (sum >> 16);
        }

        return ~sum;
    }
}