using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Scutum.Library.Security
{
    public static class PasswordStorage
    {
        public const int SaltBytes = 24;
        public const int HashBytes = 32;
        public const int Iterations = 64000;

        public static readonly PBKDF2 PBKDF2 = new PBKDF2(Iterations, HashBytes);

        public static HashedPassword CreateHashedPassword(string password)
        {
            var salt = CreateSalt(SaltBytes);
            return new HashedPassword(salt, PBKDF2.Create(password, salt));
        }

        public static HashedPassword CreateHashedPassword(string password, byte[] salt)
        {
            return new HashedPassword(salt, PBKDF2.Create(password, salt));
        }

        public static string CreateHash(string password)
        {
            var hashedPassword = CreateHashedPassword(password);
            return hashedPassword.ToString();
        }

        private static byte[] CreateSalt(int size)
        {
            using (var csprng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[size];
                csprng.GetBytes(salt);
                return salt;
            }
        }

        public static bool VerifyPassword(string password, HashedPassword hashedPassword)
        {
            var expected = PBKDF2.Create(password, hashedPassword.Salt);
            return HashedPassword.SlowEquals(hashedPassword.Hash, expected);
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            return VerifyPassword(password, new HashedPassword(hashedPassword));
        }
    }
}
