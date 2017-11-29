using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Linq;

namespace Service
{
    public class UserService
    {
        public string HashPassword(string userName, string password)
        {
            string text = password + userName + "YoungEnterprise";
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += string.Format("{0:x2}", x);
            }
            return hashString;
        }

        public string GetRandomPassword(int length)
        {
            //Discuss whether or not to include both upper and lowercase letters!
            string alphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var characters = alphanumericCharacters.Distinct().ToArray();

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[length * 8];
            rng.GetBytes(buffer);
            char[] pass = new char[length];

            for (int i = 0; i < length; i++)
            {
                ulong val = BitConverter.ToUInt64(buffer, i * 8);
                pass[i] = characters[val % (uint)characters.Length];
            }

            return new string(pass);
        }

    }
}
