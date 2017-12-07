﻿using System;
using System.Collections.Generic;
using YoungEnterprise_API.Models;
using Microsoft.EntityFrameworkCore;
using Service.Models;
using System.Linq;

namespace Service
{
    public class DatabaseService
    {
        public DatabaseService()
        {
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


            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
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
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
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

        public List<TblQuestion> GetAllQuestions()
        {
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
            {
                try
                {

                    List<TblQuestion> allQuestions = new List<TblQuestion>();
                    foreach (TblQuestion question in databaseContext.TblQuestion)
                    {
                        allQuestions.Add(question);
                    }

                    return allQuestions;

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
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
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
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
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


        public void CreateJudgePair(int judgeIdA, int judgeIdB)
        {
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
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
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
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
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
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

        private List<TblQuestion> FindQuestions(DB_YoungEnterpriseContext databaseContext, string questionCategory, string questionSubject)
        {
            List<TblQuestion> questions = new List<TblQuestion>();
            foreach (TblQuestion question in databaseContext.TblQuestion.Where(q => q.FldQuestionCategori.Equals(questionCategory) && q.FldQuestionSubject.Equals(questionSubject)))
            {
                questions.Add(question);
            }
            return questions;
        }

        public List<TblVoteAnswer> FindQuestionsAndVotes(string questionCategory, string questionSubject, int judgePairId, string teamName)
        {
            List<TblVoteAnswer> result = new List<TblVoteAnswer>();

            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
            {
                foreach (TblQuestion question in FindQuestions(databaseContext, questionCategory, questionSubject))
                {
                    TblVote vote = FindJudgePairVotes(databaseContext, question, judgePairId, teamName);
                    TblVoteAnswer voteAnswer = new TblVoteAnswer
                    {
                        FldQuestionId = question.FldQuestionId,
                        Questiontext = question.FldQuestionText,
                        QuestionModifier = question.FldQuestionModifier,
                        FldVoteId = vote == null ? 0 : vote.FldVoteId,
                        Points = vote == null ? 0 : vote.FldPoints
                    };
                    result.Add(voteAnswer);
                }
            }
            return result;
        }

        private TblVote FindJudgePairVotes(DB_YoungEnterpriseContext databaseContext, TblQuestion question, int judgePairId, string teamName)
        {
            TblVote result = null;
            var voteAnswer = databaseContext.TblVoteAnswer
                         .Where(va =>
                             va.FldQuestion.FldQuestionId == question.FldQuestionId
                             && va.FldVote.FldJudgePairId == judgePairId
                             && va.FldVote.FldTeamName == teamName
                        )
                        .FirstOrDefault();
            if (voteAnswer == null)
            {
                result = null;
            }
            else
            {
                databaseContext.Entry(voteAnswer).Reference(va => va.FldVote).Load();
                result = voteAnswer.FldVote;
            }
            return result;
        }

        public int CreateVote(int judgePairID, string teamName, int points)
        {
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
            {
                try
                {
                    TblVote vote = new TblVote()
                    {
                        FldJudgePairId = judgePairID,
                        FldTeamName = teamName,
                        FldPoints = points
                    };

                    databaseContext.TblVote.Add(vote);
                    databaseContext.SaveChanges();
                    return vote.FldVoteId;

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                    return 0;
                }
            }
        }

        public void CreateVoteAnswer(int questionID, int voteID)
        {
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
            {
                try
                {
                    TblVoteAnswer voteAnswer = new TblVoteAnswer()
                    {
                        FldQuestionId = questionID,
                        FldVoteId = voteID
                    };

                    databaseContext.TblVoteAnswer.Add(voteAnswer);
                    databaseContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        public void CreateEvent(DateTime dateTime)
        {
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
            {
                try
                {

                    TblEvent tblEvent = new TblEvent()
                    {
                        FldEventDate = dateTime
                    };

                    databaseContext.TblEvent.Add(tblEvent);
                    databaseContext.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        public void DeleteAllRecords()
        {
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
            {
                try
                {
                    databaseContext.TblVoteAnswer.RemoveRange(databaseContext.TblVoteAnswer);
                    databaseContext.TblVote.RemoveRange(databaseContext.TblVote);
                    databaseContext.TblQuestion.RemoveRange(databaseContext.TblQuestion);
                    databaseContext.TblJudgePair.RemoveRange(databaseContext.TblJudgePair);
                    databaseContext.TblJudge.RemoveRange(databaseContext.TblJudge);
                    databaseContext.TblTeam.RemoveRange(databaseContext.TblTeam);
                    databaseContext.TblSchool.RemoveRange(databaseContext.TblSchool);
                    databaseContext.TblEvent.RemoveRange(databaseContext.TblEvent);
                    databaseContext.SaveChanges();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                }
            }
        }

        public TblEvent GetCurrentEvent ()
        {
            using (DB_YoungEnterpriseContext databaseContext = GetConnection())
            {
                try
                {
                    // There should only be one event at a time, hence why this method also returns just the first event index.
                    List<TblEvent> allEvents = new List<TblEvent>();

                    foreach (TblEvent ev in databaseContext.TblEvent)
                    {
                        allEvents.Add(ev);
                    }

                    return allEvents[0];
                } catch (Exception e)
                {
                    Console.WriteLine(e.InnerException.Message);
                    return null;
                }
            }
        }
    }
}


