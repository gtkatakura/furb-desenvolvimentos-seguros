using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Scutum.Library.Security
{
    public static class CryptographyAES
    {
        public static readonly byte[] Salt = Encoding.ASCII.GetBytes("Salted-value-base");

        private static Rijndael CreateAlgorithm(byte[] key, byte[] iv)
        {
            if (key.Length != 16 && key.Length != 24 && key.Length != 32)
            {
                throw new Exception("A chave de criptografia deve possuir 16, 24 ou 32 caracteres.");
            }

            if (iv.Length != 16)
            {
                throw new Exception("O vetor de inicialização deve possuir 16 caracteres.");
            }

            var algorithm = Rijndael.Create();

            algorithm.Key = key;
            algorithm.IV = iv;

            return algorithm;
        }

        private static Tuple<byte[], byte[]> CreateProvider(string password)
        {
            using (var provider = new AesCryptoServiceProvider())
            {
                var derived = new Rfc2898DeriveBytes(password, Salt);

                provider.Key = derived.GetBytes(provider.KeySize / 8);
                provider.IV = derived.GetBytes(provider.BlockSize / 8);

                return new Tuple<byte[], byte[]>(provider.Key, provider.IV);
            }
        }

        public static string Encrypt(string value, byte[] key, byte[] iv)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new Exception("O conteúdo a ser encriptado não pode ser uma string vazia.");
            }

            var algorithm = CreateAlgorithm(key, iv);
            var encryptor = algorithm.CreateEncryptor(algorithm.Key, algorithm.IV);

            using (var msEncrypt = new MemoryStream())
            {
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var writer = new StreamWriter(csEncrypt))
                    {
                        writer.Write(value);
                    }

                    return msEncrypt.ToArray().ToString("X2");
                }
            }
        }

        public static string Encrypt(string value, string password)
        {
            var provider = CreateProvider(password);
            return Encrypt(value, provider.Item1, provider.Item2);
        }

        public static string Decrypt(string value, byte[] key, byte[] iv)
        {
            if (String.IsNullOrWhiteSpace(value))
            {
                throw new Exception("O conteúdo a ser decriptado não pode ser uma string vazia.");
            }

            if (value.Length % 2 != 0)
            {
                throw new Exception("O conteúdo a ser decriptado é inválido.");
            }

            var algorithm = CreateAlgorithm(key, iv);
            var decryptor = algorithm.CreateDecryptor(algorithm.Key, algorithm.IV);

            using (var msDecrypt = new MemoryStream(value.ToArrayBytes()))
            {
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (var srDecrypt = new StreamReader(csDecrypt))
                    {
                        return srDecrypt.ReadToEnd();
                    }
                }
            }
        }
        
        public static string Decrypt(string value, string password)
        {
            var provider = CreateProvider(password);
            return Decrypt(value, provider.Item1, provider.Item2);
        }

        public static byte[] ToArrayBytes(this string value)
        {
            int length = value.Length / 2;

            byte[] me = new byte[length];

            for (int i = 0; i < length; i++)
            {
                me[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
            }

            return me;
        }

        public static string ToString(this byte[] value, string format)
        {
            var me = value.Select(x => x.ToString(format));
            return string.Concat(me);
        }
    }
}
