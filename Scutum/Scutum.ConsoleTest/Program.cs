using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Security.Cryptography;
using Scutum.Library.Security;
using System.Text;

namespace Scutum.ConsoleTest
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            using (var provider = new AesCryptoServiceProvider())
            {
                byte[] salt = Encoding.ASCII.GetBytes("Some salt value");

                var derived = new Rfc2898DeriveBytes("some password", salt);

                var key = derived.GetBytes(provider.KeySize / 8);
                var iv = derived.GetBytes(provider.BlockSize / 8);

                var encrypted = CryptographyAES.Encrypt("value", key, iv);
                var decrypted = CryptographyAES.Decrypt(encrypted, key, iv);
                Console.WriteLine(decrypted);

                var key2 = PasswordStorage.CreateHashedPassword("teste", salt).Hash;
                var encrypted2 = CryptographyAES.Encrypt("value", provider.Key, provider.IV);
                var decrypted2 = CryptographyAES.Decrypt(encrypted2, provider.Key, provider.IV);

                Console.WriteLine(decrypted2);
            }

            Console.ReadKey();
        }
    }
}