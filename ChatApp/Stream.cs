using System.Text;

namespace ChatApp
{
    public class Stream
    {
        public static string Decode(byte[] byteMessage, int byteCount)
        {
            return Encoding.ASCII.GetString(byteMessage, 0, byteCount);
        }

        public static byte[] Encode(string message)
        {
            return Encoding.ASCII.GetBytes(message);
        }
    }
}
