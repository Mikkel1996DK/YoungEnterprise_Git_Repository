using System;
using System.Collections.Generic;
using YoungEnterprise_API.Models;
using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Service
{
    public class DatabaseService
    {
        public DB_YoungEnterpriseContext databaseContext;
        public DatabaseService()
        {
            databaseContext = GetConnection();
        }

        public DB_YoungEnterpriseContext GetConnection()
        {
            //DESKTOP-ACNIRC0 Louise
            //DESKTOP-6D9EMB1 Mikkel
            var connection = @"Server=DESKTOP-6D9EMB1;Database=DB_YoungEnterprise;Trusted_Connection=True;";
            var optionsBuilder = new DbContextOptionsBuilder<DB_YoungEnterpriseContext>();
            optionsBuilder.UseSqlServer(connection);
            DB_YoungEnterpriseContext context = new DB_YoungEnterpriseContext(optionsBuilder.Options);
            return context;
        }

        public void CreateJudge(int eventID, string judgeUsername, string judgePassword, string judgeName)
        {
            using (databaseContext)
            {
                try
                {

                    TblJudge judge = new TblJudge()
                    {
                        FldEventId = eventID,
                        FldJudgeUsername = judgeUsername,
                        FldJudgePassword = judgePassword,
                        FldJudgeName = judgeName
                    };
                    databaseContext.TblJudge.Add(judge);
                    databaseContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        public List<TblJudge> GetAllJudges()
        {
            using (databaseContext)
            {
                try
                {

                    List<TblJudge> allJudges = new List<TblJudge>();
                    foreach (TblJudge judge in databaseContext.TblJudge)
                    {
                        allJudges.Add(judge);
                    }

                    return allJudges;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    return null;
                }
            }
        }

        public void CreateSchool(int eventID, string schoolUsername, string schoolPassword, string schoolName)
        {
            using (databaseContext)
            {
                try
                {

                    TblSchool school = new TblSchool()
                    {
                        FldEventId = eventID,
                        FldSchoolUsername = schoolUsername,
                        FldSchoolPassword = schoolPassword,
                        FldSchoolName = schoolName
                    };
                    databaseContext.TblSchool.Add(school);
                    databaseContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        public List<TblSchool> GetAllSchools()
        {
            using (databaseContext)
            {
                try
                {

                    List<TblSchool> allSchools = new List<TblSchool>();
                    foreach (TblSchool school in databaseContext.TblSchool)
                    {
                        allSchools.Add(school);
                    }

                    return allSchools;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    return null;
                }
            }
        }

        public void CreateJudgePair(int judgeIdA, int judgeIdB)
        {
            using (databaseContext)
            {
                try
                {

                    TblJudgePair judgePair = new TblJudgePair()
                    {
                        FldJudgeIda = judgeIdA,
                        //FldJudgeIdaNavigation = judgeNavA,
                        FldJudgeIdb = judgeIdB
                        //FldJudgeIdbNavigation = judgeNavB
                    };

                    databaseContext.TblJudgePair.Add(judgePair);
                    databaseContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        public List<TblJudgePair> GetAllJudgePairs()
        {
            using (databaseContext)
            {
                try
                {

                    List<TblJudgePair> allJudges = new List<TblJudgePair>();
                    foreach (TblJudgePair judgePair in databaseContext.TblJudgePair)
                    {
                        allJudges.Add(judgePair);
                    }

                    return allJudges;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    return null;
                }
            }
        }

        public List<User> GetUsers()
        {
            List<TblJudge> judges = GetAllJudges();
            List<TblSchool> schools = GetAllSchools();

            List<User> users = new List<User>();


            foreach (TblJudge judge in judges)
            {
                User user = new User(false);
                user.Name = judge.FldJudgeName;
                user.UserName = judge.FldJudgeUsername;

                users.Add(user);
            }

            foreach (TblSchool school in schools)
            {
                User user = new User(true);

                user.Name = school.FldSchoolName;
                user.UserName = school.FldSchoolUsername;
                users.Add(user);
            }

            return users;
        }

        public List<TblVoteAnswer> FindVoteAnswers(TblJudgePair judgePair)
        {
            using (databaseContext)
            {
                try
                {
                    List<TblVoteAnswer> allVoteAnswers = new List<TblVoteAnswer>();
                    foreach (TblVoteAnswer voteAnswer in databaseContext.TblVoteAnswer)
                    {
                        voteAnswer.Questiontext = voteAnswer.FldQuestion.FldQuestionText;
                        voteAnswer.QuestionModifier = voteAnswer.FldQuestion.FldQuestionModifier;
                        voteAnswer.Points = voteAnswer.FldVote.FldPoints;

                        allVoteAnswers.Add(voteAnswer);
                    }

                    return allVoteAnswers;

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    return null;
                }
            }
        }

        public List<TblQuestion> FindQuestions(string questionCatagory, string questionSubject)
        {
            // Gets a list of questions according to catagory and subject. 
            // TODO add fldQuestionSubject to db

            using (databaseContext)
            {
                try
                {
                    List<TblQuestion> questions = new List<TblQuestion>();
                    foreach (TblQuestion question in databaseContext.TblQuestion)
                    {
                       if(question.FldQuestionCategori.Equals(questionCatagory) && question.FldQuestionSubject.Equals(questionSubject))
                        questions.Add(question);
                    }

                    return questions;
                }
                catch (Exception e)
                {
                    // Todo Create Log instead. Look at JAVA example!
                    Console.WriteLine(e.InnerException.Message);
                    return null;
                }
            }
        }
    }
}


       