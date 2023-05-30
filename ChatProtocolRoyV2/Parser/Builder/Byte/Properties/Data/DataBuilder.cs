﻿using ChatProtocolRoyV2.Constants;
using ChatProtocolRoyV2.Entities;
using ChatProtocolRoyV2.Helper.Byte;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Length;
using ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Type;

namespace ChatProtocolRoyV2.Parser.Builder.Byte.Properties.Data;

public class DataBuilder : IDataBuilder
{
    public string Build(IEnumerable<byte> input)
    {
        var enumerable = input as byte[] ?? input.ToArray();
        var typeBuilder = new TypeBuilder();
        var type = typeBuilder.Build(enumerable);
        var inputBytes = enumerable.ToArray();
        var dataBytes = Array.Empty<byte>();
        var lengthBuilder = new LengthBuilder();
        var helper = new HelpBytes();
        string data;
        switch (type)
        {
            case MessageType.TextMessage:
                Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX + 1, dataBytes, 0,
                    lengthBuilder.Build(enumerable));
                data = helper.FromByteArray<string>(dataBytes);
                return data;
            case MessageType.FileMessage:
                Array.Copy(inputBytes, Indexes.LENGTH_OF_DATA_INDEX + 1, dataBytes, 0,
                    lengthBuilder.Build(enumerable));
                data = helper.FromByteArray<string>(dataBytes);
                return data;

            default:
                throw new Exception("no matching type");
        }
    }
}