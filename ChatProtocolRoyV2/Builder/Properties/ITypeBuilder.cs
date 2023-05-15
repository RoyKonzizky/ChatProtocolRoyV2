namespace ChatProtocolRoyV2.Builder.Properties;

public interface ITypeBuilder : IBuilder<object, byte[]>
{
    ITypeBuilder WithType(object type);
}