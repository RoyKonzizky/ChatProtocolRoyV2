namespace ChatProtocolRoyV2.Constants;

public static class Lengths
{

    #region Message

    public const int SYNC_LENGTH = 1;

    public const int GUID_LENGTH = 16;

    public const int TYPE_LENGTH = 4;

    public const int CHECKSUM_LENGTH = 4;

    public const int TAIL_LENGTH = 1;

    public const int LENGTH_OF_DATA_LENGTH = 4;


        #region File

        public const int FILE_NAME_LENGTH = 8;

        public const int FILE_TYPE_LENGTH = 4;

        //use sizeof(int) * 3, explain that DateOnly is 3 fields of int to represent the full date
        public const int DATE_ONLY_LENGTH = 12;

        #endregion

    #endregion
}