using System.Text;

namespace ChatProtocolRoyV2.Utilities;

public class ExtractFileName
{
    public static string FileNameExtractor(byte[] byteArray)
    {
        StringBuilder fileNameBuilder = new StringBuilder();
    
        for (int i = 0; i < byteArray.Length; i++)
        {
            if ((byteArray[i] >= 'A' && byteArray[i] <= 'Z') || (byteArray[i] >= 'a' && byteArray[i] <= 'z') ||
                (byteArray[i] >= '0' && byteArray[i] <= '9') || (byteArray[i] == '.' || byteArray[i] == '_'))
            {
                char character = (char)byteArray[i];
                fileNameBuilder.Append(character);
            }
            else
            {
                break;
            }
        }
    
        return fileNameBuilder.ToString();
    }

}