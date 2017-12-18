using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using YoungEnterprise_API.Models;
using System.Linq;
using Service.Models;

namespace ServiceTest
{
    [TestClass]
    public class DatabaseServiceTest
    {

        private DatabaseService service = new DatabaseService();
        private UserService userService = new UserService();

        [TestMethod]
        public void CreateEventTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            var evt = service.GetCurrentEvent();
            Assert.IsNotNull(evt);
            Assert.AreEqual(eventID, evt.FldEventId);
            Assert.AreEqual(0, evt.TblJudge.Count());
        }

        [TestMethod]
        public void CreateJudgeTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            service.CreateJudge(eventID, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            Assert.AreEqual(1, service.GetAllJudges().Count());
        }

        [TestMethod]
        public void CreateJudgeDuplicateTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            service.CreateJudge(eventID, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            try
            {
                service.CreateJudge(eventID, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
                Assert.Fail("Expected exception - dublicate judge");
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // ok
            }
        }

        [TestMethod]
        public void CreateSchoolDuplicateTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            service.CreateSchool(eventID, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            try
            {
                service.CreateSchool(eventID, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
                Assert.Fail("Expected exception - dublicate judge");
            }
            catch (AssertFailedException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                // ok
            }
        }

        [TestMethod]
        public void CreateSchoolTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            service.CreateSchool(eventID, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            Assert.AreEqual(1, service.GetAllSchools().Count());
        }

        [TestMethod]
        public void CreateJudgePairTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            service.CreateJudge(eventID, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            service.CreateJudge(eventID, "mikkel@gmail.com", userService.HashPassword("mikkel@gmail.com", "12345"), "Mikkel");
            service.CreateJudge(eventID, "a@gmail.com", userService.HashPassword("a@gmail.com", "12345"), "A");
            service.CreateJudge(eventID, "b@gmail.com", userService.HashPassword("b@gmail.com", "12345"), "B");
            service.CreateJudge(eventID, "c@gmail.com", userService.HashPassword("c@gmail.com", "12345"), "C");

            service.CreateJudgePairs();

            var judgePairs = service.GetAllJudgePairs();
            Assert.AreEqual(2, judgePairs.Count());
            // check judge uniqueness
            HashSet<int> uniqueJudgeIds = new HashSet<int>();
            foreach (var judgePair in judgePairs)
            {
                uniqueJudgeIds.Add(judgePair.FldJudgeIda);
                uniqueJudgeIds.Add(judgePair.FldJudgeIdb);
            }
            Assert.AreEqual(4, uniqueJudgeIds.Count());
        }

        [TestMethod]
        public void CreateTeamTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            var school = service.CreateSchool(eventID, "s@gmail.com", userService.HashPassword("s@gmail.com", "12345"), "Business College Syd");
            byte[] report = Encoding.ASCII.GetBytes("Hello this is a test report");
            service.CreateTeam("TestTeam", school.FldSchoolId, "Trade and Skills", report);
            Assert.AreEqual(1, service.GetAllTeams().Count());
        }

        [TestMethod]
        public void VoteTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            // Judges
            service.CreateJudge(eventID, "a@gmail.com", userService.HashPassword("a@gmail.com", "12345"), "A");
            service.CreateJudge(eventID, "b@gmail.com", userService.HashPassword("b@gmail.com", "12345"), "B");
            service.CreateJudge(eventID, "c@gmail.com", userService.HashPassword("c@gmail.com", "12345"), "C");
            service.CreateJudge(eventID, "d@gmail.com", userService.HashPassword("d@gmail.com", "12345"), "D");
            service.CreateJudgePairs();
            var judgePairs = service.GetAllJudgePairs();
            Assert.AreEqual(2, judgePairs.Count());
            var pair1 = judgePairs[0];
            var pair2 = judgePairs[1];

            // School
            var school = service.CreateSchool(eventID, "s@gmail.com", userService.HashPassword("s@gmail.com", "12345"), "Business College Syd");

            // Teams 
            service.CreateTeam("EasyOn", school.FldSchoolId, "Trade and Skills", new byte[10]);
            service.CreateTeam("Two", school.FldSchoolId, "Trade and Skills", new byte[10]);

            // Questions (already setup)
            var questions = service.GetAllQuestions();
            var question1 = questions[0];
            var question2 = questions[1];

            // Do
            var voteModel = new CreateVoteModel()
            {
                FldJudgeUsername = service.GetJudgeByID(pair1.FldJudgeIda).FldJudgeUsername,
                FldPoints = 10,
                FldQuestiontext = question1.FldQuestionText,
                FldTeamName = "EasyOn"
            };
            service.Vote(voteModel);

            var voteModel2 = new CreateVoteModel()
            {
                FldJudgeUsername = service.GetJudgeByID(pair1.FldJudgeIda).FldJudgeUsername,
                FldPoints = 3,
                FldQuestiontext = question2.FldQuestionText,
                FldTeamName = "EasyOn"
            };
            service.Vote(voteModel2);

            // Assertions
            var vote1 = service.FindJudgePairVotes(question1.FldQuestionId, pair1.FldJudgePairId, "EasyOn");
            Assert.IsNotNull(vote1);
            Assert.AreEqual(10, vote1.FldPoints);

            var vote2 = service.FindJudgePairVotes(question2.FldQuestionId, pair1.FldJudgePairId, "EasyOn");
            Assert.IsNotNull(vote2);
            Assert.AreEqual(3, vote2.FldPoints);

            // Revote
            voteModel.FldPoints = 5;
            service.Vote(voteModel);

            // Assertions
            var vote3 = service.FindJudgePairVotes(question1.FldQuestionId, pair1.FldJudgePairId, "EasyOn");
            Assert.IsNotNull(vote3);
            Assert.AreEqual(5, vote3.FldPoints);
        }

        [TestMethod]
        public void FindQuestionAndVotes()
        {

            var eventID = service.CreateEvent(DateTime.Now);
            // Judges
            service.CreateJudge(eventID, "a@gmail.com", userService.HashPassword("a@gmail.com", "12345"), "A");
            service.CreateJudge(eventID, "b@gmail.com", userService.HashPassword("b@gmail.com", "12345"), "B");
            service.CreateJudge(eventID, "c@gmail.com", userService.HashPassword("c@gmail.com", "12345"), "C");
            service.CreateJudge(eventID, "d@gmail.com", userService.HashPassword("d@gmail.com", "12345"), "D");
            service.CreateJudgePairs();
            var judgePairs = service.GetAllJudgePairs();
            Assert.AreEqual(2, judgePairs.Count());
            var pair1 = judgePairs[0];
            var pair2 = judgePairs[1];

            // School
            var school = service.CreateSchool(eventID, "s@gmail.com", userService.HashPassword("s@gmail.com", "12345"), "Business College Syd");

            // Teams 
            service.CreateTeam("EasyOn", school.FldSchoolId, "Trade and Skills", new byte[10]);
            service.CreateTeam("Two", school.FldSchoolId, "Trade and Skills", new byte[10]);
            // Questions (already setup)
            var questions = service.GetAllQuestions();
            var question1 = questions[0];

            // Votes
            var voteModel = new CreateVoteModel()
            {
                FldJudgeUsername = service.GetJudgeByID(pair1.FldJudgeIda).FldJudgeUsername,
                FldPoints = 2,
                FldQuestiontext = question1.FldQuestionText,
                FldTeamName = "EasyOn"
            };
            service.Vote(voteModel);

            List<TblVoteAnswer> voteAnswer = service.FindQuestionsAndVotes("Report", "Trade and Skills", pair1.FldJudgePairId, "EasyOn");
            Assert.AreEqual(2, voteAnswer.Count);
            Assert.AreEqual(1, voteAnswer.Where(a => a.Points == 0).Count());
            Assert.AreEqual(1, voteAnswer.Where(a => a.Points == 2).Count());
        }

        [TestMethod]
        public void FindTeamResultsTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            // Judges
            service.CreateJudge(eventID, "a@gmail.com", userService.HashPassword("a@gmail.com", "12345"), "A");
            service.CreateJudge(eventID, "b@gmail.com", userService.HashPassword("b@gmail.com", "12345"), "B");
            service.CreateJudge(eventID, "c@gmail.com", userService.HashPassword("c@gmail.com", "12345"), "C");
            service.CreateJudge(eventID, "d@gmail.com", userService.HashPassword("d@gmail.com", "12345"), "D");
            service.CreateJudgePairs();
            var judgePairs = service.GetAllJudgePairs();
            Assert.AreEqual(2, judgePairs.Count());
            var pair1 = judgePairs[0];
            var pair2 = judgePairs[1];

            // School
            var school = service.CreateSchool(eventID, "s@gmail.com", userService.HashPassword("s@gmail.com", "12345"), "Business College Syd");

            // Teams 
            service.CreateTeam("EasyOn", school.FldSchoolId, "Trade and Skills", new byte[10]);
            service.CreateTeam("Two", school.FldSchoolId, "Trade and Skills", new byte[10]);
            // Questions (already setup)
            var questions = service.GetAllQuestions();
            var question1 = questions[0];

            // Votes
            var voteModel = new CreateVoteModel()
            {
                FldJudgeUsername = service.GetJudgeByID(pair1.FldJudgeIda).FldJudgeUsername,
                FldPoints = 2,
                FldQuestiontext = question1.FldQuestionText,
                FldTeamName = "EasyOn"
            };
            service.Vote(voteModel);

            List<TeamResultModel> teamResults = service.FindTeamResults();
            Assert.AreEqual(2, teamResults.Count);
            Assert.AreEqual(2*question1.FldQuestionModifier, teamResults[0].OverallPoints);
        }

        [TestMethod]
        public void DeleteJudgeTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);

            // Judges
            service.CreateJudge(eventID, "a@gmail.com", userService.HashPassword("a@gmail.com", "12345"), "A");
            service.CreateJudge(eventID, "b@gmail.com", userService.HashPassword("b@gmail.com", "12345"), "B");

            List<TblJudge> allJudges = service.GetAllJudges();
            service.DeleteJudge(allJudges[0]);

            // Assertion
            Assert.AreEqual(1, service.GetAllJudges().Count);
        }

        [TestMethod]
        public void DeleteSchoolTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);

            // School
            var school = service.CreateSchool(eventID, "s@gmail.com", userService.HashPassword("s@gmail.com", "12345"), "Business College Syd");
            List<TblSchool> allSchools = service.GetAllSchools();
            service.DeleteSchool(allSchools[0]);

            // Assertion
            Assert.AreEqual(0, service.GetAllSchools().Count);
        }
    }
}
