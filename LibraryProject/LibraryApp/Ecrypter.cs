using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp
{
    class Encrypter
    {
        public string Encrypt(string password)
        {
            var utf8 = new UTF8Encoding();
            using (var md5 = new MD5CryptoServiceProvider())
            {
                var data = md5.ComputeHash(utf8.GetBytes(password));
                return Convert.ToBase64String(data);
            }
        }
    }
}
