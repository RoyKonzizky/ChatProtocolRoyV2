namespace ChatProtocolRoyV2.Generator.Types;

public class ChecksumByteArrayCalculator : IChecksumByteArrayCalculator
{
    public int CalculateChecksum(byte[] input){
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

        return (ushort)~sum;
    }
}
//TODO better checksum needed