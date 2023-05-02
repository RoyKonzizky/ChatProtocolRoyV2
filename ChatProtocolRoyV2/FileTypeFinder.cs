namespace ChatProtocolRoyV2;

public class FileTypeFinder
{
    public string FindFileType(byte[] headerBytes)
    {
        // define the magic bytes for various file types
        Dictionary<string, byte[]> magicBytes = new Dictionary<string, byte[]>
        {
            { ".txt", new byte[] { 0xEF, 0xBB, 0xBF } },
            { ".png", new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A } },
            { ".jpg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 } },
            { ".jpeg", new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 } },
            { ".gif", new byte[] { 0x47, 0x49, 0x46, 0x38, 0x37, 0x61 } },
            { ".wav", new byte[] { 0x52, 0x49, 0x46, 0x46 } },
            { ".mp3", new byte[] { 0x49, 0x44, 0x33 } },
            { ".mp4", new byte[] { 0x00, 0x00, 0x00, 0x18, 0x66, 0x74, 0x79, 0x70 } },
            { ".pdf", new byte[] { 0x25, 0x50, 0x44, 0x46 } },
            { ".zip", new byte[] { 0x50, 0x4B, 0x03, 0x04 } },
            { ".rar", new byte[] { 0x52, 0x61, 0x72, 0x21, 0x1A, 0x07, 0x00 } },

        };

        foreach (var (key, value) in magicBytes)
        {
            if (headerBytes.Take(value.Length).SequenceEqual(value))
            {
                return key;
            }
        }

        return "unknown";
    }


    
}