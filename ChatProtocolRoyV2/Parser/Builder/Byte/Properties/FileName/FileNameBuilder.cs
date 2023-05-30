﻿using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.FileName;

public class FileNameBuilder : IFileNameBuilder
{
    public string Build(IEnumerable<byte> input)
    {
        var inputBytes = input.ToArray();
        var nameBytes = Array.Empty<byte>();
        var lengthBuilder = new LengthBuilder();
        Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX + 1 +  lengthBuilder.Build(inputBytes) + Lengths.FILE_TYPE_LENGTH + Lengths.DATE_ONLY_LENGTH, nameBytes, 0, Lengths.FILE_NAME_LENGTH);
        var helper = new HelpBytes();
        var nameFile = helper.FromByteArray<string>(nameBytes);
        return nameFile;
    }
}