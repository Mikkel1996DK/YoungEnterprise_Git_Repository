using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;

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

        public string ApiTest ()
        {
            WebClient client = new WebClient();

            //client.DownloadData("");



            return null;
        }

    }
}
