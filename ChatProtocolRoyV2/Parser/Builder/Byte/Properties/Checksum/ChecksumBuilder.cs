﻿using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Generator.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Type;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Checksum;

public class ChecksumBuilder : IChecksumBuilder
{
    public uint Build(IEnumerable<byte> input)
    {
        //find the index of the checksum in the package
        //extract the bytes
        //remove pending chart
        //parse to uint in the correct format
        var enumerable = input as byte[] ?? input.ToArray();
        var inputBytes = enumerable.ToArray();
        var checksumBytes = Array.Empty<byte>();
        var typeBuilder = new TypeBuilder();
        var type = typeBuilder.Build(enumerable);
        var generator = new Generate();
        var lengthBuilder = new LengthBuilder();
        uint checksum;
        switch (type)
        {
            case MessageType.TextMessage:
                Array.Copy(inputBytes, lengthBuilder.Build(enumerable) + 1, checksumBytes, 0, Lengths.CHECKSUM_LENGTH);
                checksum = generator.FromByteArray<uint>(checksumBytes);
                return checksum;
            case MessageType.FileMessage:
                Array.Copy(inputBytes, lengthBuilder.Build(enumerable) + 1, checksumBytes, 0, Lengths.CHECKSUM_LENGTH);
                checksum = generator.FromByteArray<uint>(checksumBytes);
                return checksum;

            default:
                throw new Exception("no matching type");
        }
    }
}