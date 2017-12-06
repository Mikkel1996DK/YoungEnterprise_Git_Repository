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
        public void CreateJudgePairs ()
        {
            DatabaseService dbService = new DatabaseService();

            List<TblJudge> judgeList = dbService.GetAllJudges();

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
            } else
            {
                judges = judgeList;
            }
            
            // Make judge pairs
            List<TblJudgePair> judgePairs = new List<TblJudgePair>();
            for (int i = 0; i < judges.Count() - 1; i++)
            {
                TblJudgePair judgePair = new TblJudgePair();

                judgePair.FldJudgeIda = judges[i].FldJudgeId;
                //judgePair.FldJudgeIdaNavigation = judges[i];

                judgePair.FldJudgeIdb = judges[i + 1].FldJudgeId;
                //judgePair.FldJudgeIdbNavigation = judges[i + 1];

                i++;

                judgePairs.Add(judgePair);
            }

            // Add judges to the database.
            foreach (TblJudgePair pair in judgePairs)
            {
                dbService.CreateJudgePair(pair.FldJudgeIda, pair.FldJudgeIdb);
            }

            dbService = null;
        }

        public int GetJudgePairID (string judgeUsername)
        {
            DatabaseService dbService = new DatabaseService();
            List<TblJudge> judges = dbService.GetAllJudges();
            List<TblJudgePair> judgePairs = dbService.GetAllJudgePairs();
            dbService = null;

            TblJudge selectedJudge = new TblJudge();
            foreach (TblJudge judge in judges)
            {
                if (judge.FldJudgeUsername.Equals(judgeUsername))
                {
                    selectedJudge = judge;
                    break;
                }
            }


            TblJudgePair selectedJudgePair = null;
            foreach (TblJudgePair judgePair in judgePairs)
            {
                if (judgePair.FldJudgeIda == selectedJudge.FldJudgeId || judgePair.FldJudgeIdb == selectedJudge.FldJudgeId)
                {
                    selectedJudgePair = judgePair;
                    break;
                }
            }

            if (selectedJudgePair == null)
            {
                return 0;
            } else
            {
                return selectedJudgePair.FldJudgePairId;
            }
        }

        public int GetQuestionID(string questionText, double questionModifier)
        {
            DatabaseService dbService = new DatabaseService();
            List<TblQuestion> questions = dbService.GetAllQuestions();
            dbService = null;

            TblQuestion selectedQuestion = new TblQuestion();
            foreach (TblQuestion question in questions)
            {
                if (question.FldQuestionText.Equals(questionText) || question.FldQuestionModifier == questionModifier)
                {
                    selectedQuestion = question;
                    break;
                }
            }
            return selectedQuestion.FldQuestionId;
        }
    }
}
