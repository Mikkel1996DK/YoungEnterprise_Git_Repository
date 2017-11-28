using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using Newtonsoft.Json;

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

        public static List<string> ApiTest ()
        {
            List<string> judges = new List<string>();
            WebClient client = new WebClient();

            // http://localhost:53112/api/TblJudgePairs
            Stream stream = client.OpenRead("http://localhost:53112/api/TblJudgePairs");

            using (stream)
            {
                StreamReader reader = new StreamReader(stream);

                using (reader)
                {
                    var json = reader.ReadToEnd();
                    dynamic text = JsonConvert.DeserializeObject<dynamic>(json);

                    var features = text.features;
                    foreach (var judge in features)
                    {
                        var id = judge.properties.fldJudgePairId; // check this
                        judges.Add(id + "");
                    }
                }

            }


            return judges;
        }

    }
}
