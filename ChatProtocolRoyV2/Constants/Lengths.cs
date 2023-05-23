namespace ChatProtocolRoyV2.Constants;

public static class Lengths
{
    //TODO lengths of properties in the package

    #region ConstsForAllMessages

    public const int SYNC_LENGTH = 1;

    public const int GUID_LENGTH = 16;

    public const int TYPE_LENGTH = 4;

    public const int CHECKSUM_LENGTH =  4;

    public const int TAIL_LENGTH = 1;
    
    public const int LENGTH_OF_DATA_LENGTH = 4;
    
    #endregion

    
    #region ConstsForFileMessages

    public const int FILE_NAME_LENGTH = 8;
    
    public const int FILE_TYPE_LENGTH = 4;
    
    public const int DATE_ONLY_LENGTH = 4*3;

    #endregion

}