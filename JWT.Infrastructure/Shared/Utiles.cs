using System.Security.Cryptography; 

namespace JSWSample.Infrastructure.Shared
{
    public class Utiles
    {
        public static string GenerateRandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string HashedString (string text)
        {
            SHA256 sha256 = SHA256.Create();

            string inputString = "example string to hash";
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(inputString);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);

            string hashString = BitConverter.ToString(hashBytes).Replace("-", "");
            return hashString;
        }
    }
}
