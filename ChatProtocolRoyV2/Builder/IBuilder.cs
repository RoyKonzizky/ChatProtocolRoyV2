namespace ChatProtocolRoyV2.Builder;

public interface IBuilder<out TBuild,in TMessageBase>
{
    TBuild Build(TMessageBase input);
}

//Make IBuilder for each attribute of a packet
//TODO find what is actually supposed to be written there