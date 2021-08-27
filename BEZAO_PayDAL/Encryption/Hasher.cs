using System;
using System.Security.Cryptography;
using BEZAO_PayDAL.Entities;

namespace BEZAO_PayDAL.Encryption
{
    class Hasher
    {       
        static BezaoPayContext DBContext = new BezaoPayContext();

        public static void applyHashing( string _password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            var pbkdf2 = new Rfc2898DeriveBytes(_password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            string savedPasswordHash = Convert.ToBase64String(hashBytes);
            DBContext.Users.Add(new User
            {
                Id = 1,
                Name = "Francis Sorry",
                Email = "sorry.sir@abeg.com",
                Birthday = new DateTime(1990, 10, 24),
                Created = DateTime.Now,
                IsActive = true,
                AccountId = 1,
                Username = "francissorry",
                Password = savedPasswordHash
            });           
        }        
    }
}
