using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Linq;
using YoungEnterprise_API.Models;

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

        public bool CheckJudgeLogin (string username, string password)
        {
            // Get all the judges in a generic list.
            DatabaseService dbService = new DatabaseService();
            List<TblJudge> judgeList = dbService.GetAllJudges();
            

            // Loops through all the judges in the database and returns true only if it finds a match with both username and password
            // at once.
            foreach (TblJudge judge in judgeList)
            {
                if (judge.FldJudgeUsername == username && judge.FldJudgePassword == password)
                {
                    return true;
                }
            }

            return false;
        }


        // Make test for this.
        public List<TblJudgePair> CreateJudgePairs (List<TblJudge> judgeList)
        {
            // We've been told that there will always be 24 judges.
            // Therefore the method should just pair up the judges as long as there's two judges left.
            // If there's an excess judge, that judge should not be included.
            // Then trimming the amount of judgepairs down to 12.

            List<TblJudge> judges = new List<TblJudge>();

            // This trims the amount of judges to be an equal number.
            if (judgeList.Count() % 2 != 0)
            {
                for (int i = 0; i < judgeList.Count() - 1; i++)
                {
                    judges.Add(judgeList[i]);
                }
            }

            // Make judge pairs

            // i=0 length = 3    | judge1, judge2, judge3, judge4     |
            // i=0 length = 2    | judge2, judge3, judge4             | judgePair1(judge1,       )
            // i=0 length = 1    | judge3, judge4                     | judgePair1(judge1, judge2)
            // i=1 length = 0    | judge4                             | judgePair1(judge1, judge2), judgePair2(judge3,       )
            // i=1 length = null |                                    | judgePair1(judge1, judge2), judgePair2(judge3, judge4)
            List<TblJudgePair> judgePairs = new List<TblJudgePair>();
            for (int i = 0; i < judges.Count(); i++)
            {
                TblJudgePair judgePair = new TblJudgePair();
                judgePair.FldJudgeIda = judges[i].FldJudgeId;
                judgePair.FldJudgeIdaNavigation = judges[i];

                judges.Remove(judges[i]);

                judgePair.FldJudgeIdb = judges[i].FldJudgeId;
                judgePair.FldJudgeIdbNavigation = judges[i];

                judges.Remove(judges[i]);

                judgePairs.Add(judgePair);
            }

            return judgePairs;
        }
    }
}
