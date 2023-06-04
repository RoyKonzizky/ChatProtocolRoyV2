namespace ChatProtocolRoyV2.Constants;

using static Lengths;

public static class Indexes
{
    #region ConstsForAllTypes

    public const int SYNC_INDEX = 0;

    public const int GUID_INDEX = SYNC_INDEX + SYNC_LENGTH;

    public const int TYPE_INDEX = GUID_INDEX + GUID_LENGTH;

    public const int LENGTH_OF_DATA_INDEX = TYPE_INDEX + TYPE_LENGTH;

    #endregion
}