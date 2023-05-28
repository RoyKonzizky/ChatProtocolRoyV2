using System.Collections;

namespace ChatProtocolRoyV2.Generator.Byte;

//todo use MessageBase and creational design patterns into IEnumrable<byte> instead of arraylist
public interface IByteGenerator : IGenerator<ArrayList, IEnumerable<byte>>
{
}