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

    
    #region ConstsForFileMessage
    
    public const int FILE_TYPE_INDEX = TYPE_INDEX + TYPE_LENGTH;

    public const int FILE_NAME_INDEX = FILE_TYPE_INDEX + FILE_TYPE_LENGTH;

    public const int DATE_ONLY_INDEX = FILE_NAME_INDEX + FILE_NAME_LENGTH;

    public const int LENGTH_OF_DATA_INDEX_FILE = DATE_ONLY_INDEX + DATE_ONLY_LENGTH;

    #endregion
    //TODO add values and may need to add different values for the other indexes for the FileMessage Packet, may need to write ifs for all the effected builders to differentiate the cases
}

//Builder - add more builders for file specific properties and change the packet accordingly(use the type as an anchor)
//Data Module - no need to reformat anymore
//Generator Module - delete the packet class and reformat the generator itself
//Parser module - Adjust according to what the builder contains

