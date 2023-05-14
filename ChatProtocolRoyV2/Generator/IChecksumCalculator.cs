namespace ChatProtocolRoyV2.Generator;

public interface IChecksumCalculator<in TInput>
{
    uint CalculateChecksum(TInput input);
}
//TODO add startindex and endindex-can be added and used need to ask how necessary as the parser already can work without it, however it will fill the empty spot of the type