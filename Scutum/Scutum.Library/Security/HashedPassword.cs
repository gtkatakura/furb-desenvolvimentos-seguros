using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scutum.Library.Security
{
    public struct HashedPassword
    {
        public const int SaltIndex = 0;
        public const int HashIndex = 1;
        public const char Delimiter = ':';

        public byte[] Salt { get; set; }
        public byte[] Hash { get; set; }

        public HashedPassword(byte[] salt, byte[] hash) : this()
        {
            this.Salt = salt;
            this.Hash = hash;
        }

        public HashedPassword(string salt, string hash)
        {
            this.Salt = Convert.FromBase64String(salt);
            this.Hash = Convert.FromBase64String(hash);
        }

        public HashedPassword(string[] values) : this(values[SaltIndex], values[HashIndex]) { }

        public HashedPassword(string values) : this(values.Split(Delimiter)) { }

        public IDictionary<int, string> ToDictionary()
        {
            return new SortedDictionary<int, string>
            {
                [SaltIndex] = Convert.ToBase64String(this.Salt),
                [HashIndex] = Convert.ToBase64String(this.Hash)
            };
        }

        public override string ToString()
        {
            var dictionary = this.ToDictionary();
            return string.Join(Delimiter.ToString(), dictionary.Values);
        }

        public static bool SlowEquals(byte[] hash1, byte[] hash2)
        {
            var diff = (uint)hash1.Length ^ (uint)hash2.Length;

            for (var i = 0; i < hash1.Length && i < hash2.Length; i++)
            {
                diff |= (uint)(hash1[i] ^ hash2[i]);
            }

            return diff == 0;
        }
    }
}
