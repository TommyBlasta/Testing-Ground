using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TestingGround.Functions
{
    class Hashing
    {

        public string Hash(string pass, string salt)
        {
            var rfc = new Rfc2898DeriveBytes(pass, Encoding.UTF8.GetBytes(salt));
            byte[] hash = rfc.GetBytes(20);
            return Encoding.UTF8.GetString(hash);
        }
        public string GenerateSalt()
        {
            byte[] salt = new byte[16];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(salt);
            }
            return Encoding.UTF8.GetString(salt);
        }
    }
}
