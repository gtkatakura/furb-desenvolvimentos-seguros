using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Scutum.Library.Security
{
    public class PBKDF2
    {
        public int Iterations { get; set; }
        public int HashSize { get; set; }

        public PBKDF2(int iterations, int hashSize)
        {
            this.Iterations = iterations;
            this.HashSize = hashSize;
        }

        public byte[] Create(string password, byte[] salt)
        {
            using (var algorithm = new Rfc2898DeriveBytes(password, salt))
            {
                algorithm.IterationCount = this.Iterations;
                return algorithm.GetBytes(this.HashSize);
            }
        }
    }
}
