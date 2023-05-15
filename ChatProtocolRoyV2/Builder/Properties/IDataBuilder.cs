namespace ChatProtocolRoyV2.Builder.Properties;

public interface IDataBuilder : IBuilder<object, byte[]>
{
    IDataBuilder WithType(object type);
    IDataBuilder WithData(byte[] data);
}