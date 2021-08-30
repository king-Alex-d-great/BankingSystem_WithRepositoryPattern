using System;
using System.Security.Cryptography;

namespace BEZAO_PayDAL.Encryption
{
    public static class Hasher
    {
        static string  pepper = "KingAlexWroteThis";
        static string  _pepper;
        static RNGCryptoServiceProvider rand = new RNGCryptoServiceProvider();

        private static string Pepper
        {
            get
            {                             
                var pepper = new byte[8];
                rand.GetBytes(pepper);
                _pepper = BitConverter.ToString(pepper).ToLower() + pepper;
                return _pepper;
            }
        }

        public static string getSalt()
        {
            var salt = new byte[16];
            rand.GetBytes(salt);
            return BitConverter.ToString(salt).ToLower();
        }

        public static string hashPassword(byte[] password, byte[] salt)
        {
            var securePassword = new Rfc2898DeriveBytes(password, salt, 10000);
            var saltedPassword = Convert.ToBase64String(securePassword.GetBytes(30));
            var Password = saltedPassword + _pepper;
            return Password;
        }
    }
}
