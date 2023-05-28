namespace ChatProtocolRoyV2.Constants;

using static Lengths;

public static class Indexes
{
    #region ConstsForAllTypes

    public const int SYNC_INDEX = 0;

    public const int GUID_INDEX = SYNC_INDEX + SYNC_LENGTH;

    public const int TYPE_INDEX = GUID_INDEX + GUID_LENGTH;

    #endregion

    #region ConstsForTextMessage

    public const int LENGTH_OF_DATA_INDEX_TEXT = TYPE_INDEX + TYPE_LENGTH;

    #endregion

    //TODO remove from file of consts and calc during runtime instead
    #region ConstsForFileMessage

    public const int FILE_TYPE_INDEX = TYPE_INDEX + TYPE_LENGTH;

    public const int FILE_NAME_INDEX = FILE_TYPE_INDEX + FILE_TYPE_LENGTH;

    public const int DATE_ONLY_INDEX = FILE_NAME_INDEX + FILE_NAME_LENGTH;

    public const int LENGTH_OF_DATA_INDEX_FILE = DATE_ONLY_INDEX + DATE_ONLY_LENGTH;

    #endregion
}