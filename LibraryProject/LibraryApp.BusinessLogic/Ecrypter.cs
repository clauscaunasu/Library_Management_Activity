using System;
using System.Security.Cryptography;
using System.Text;

namespace LibraryApp.BusinessLogic
{
    public class Encrypter
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
