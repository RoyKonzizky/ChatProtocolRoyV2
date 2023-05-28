namespace ChatProtocolRoyV2.ChecksumCalculator.Byte;

public class ChecksumByteArrayCalculator : IChecksumByteArrayCalculator
{
    public uint CalculateChecksum(IEnumerable<byte> input)
    {
        //todo replace with foreach sum all the bytes values to one signature value(uint)
        var enumerable = input as byte[] ?? input.ToArray();
        var length = enumerable.Length;
        var i = 0;

        uint sum = 0;
        while (length > 1)
        {
            sum += (ushort)((enumerable[i++] << 8) | enumerable[i++]);
            length -= 2;
        }

        if (length > 0) sum += (ushort)(enumerable[i] << 8);

        while (sum >> 16 != 0) sum = (sum & 0xFFFF) + (sum >> 16);

        return ~sum;
    }
}