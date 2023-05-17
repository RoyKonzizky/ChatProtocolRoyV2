using ChatProtocolRoyV2.Data;

namespace ChatProtocolRoyV2.Builder.Properties.Data;

public interface IDataBuilder<T> : IBuilder<T, MessageBase>
{
    IDataBuilder<T> WithData<T>(T data);
}

//TODO correct it as it shows errors