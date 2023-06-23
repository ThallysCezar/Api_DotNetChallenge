using System.Security.Cryptography;

namespace ProjectAPI.Application
{
    public class Key
    {
        public static string Secret = GenerateRandomKey();

        public static string GenerateRandomKey()
        {
            byte[] keyBytes = new byte[32]; // 32 bytes = 256 bits
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(keyBytes);
            }
            return Convert.ToBase64String(keyBytes);
        }
    }   
}
