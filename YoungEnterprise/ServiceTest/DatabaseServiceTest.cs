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
        public void CreateSchoolTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            service.CreateSchool(eventID, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            Assert.AreEqual(1, service.GetAllSchools().Count());
        }
        [TestMethod]
        public void CreateSchoolDuplicateTest()
        {
            Assert.Fail("TODO");
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

            userService.CreateJudgePairs();

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
        public void VoteTest()
        {
            var eventID = service.CreateEvent(DateTime.Now);
            // Judges
            service.CreateJudge(eventID, "a@gmail.com", userService.HashPassword("a@gmail.com", "12345"), "A");
            service.CreateJudge(eventID, "b@gmail.com", userService.HashPassword("b@gmail.com", "12345"), "B");
            service.CreateJudge(eventID, "c@gmail.com", userService.HashPassword("c@gmail.com", "12345"), "C");
            service.CreateJudge(eventID, "d@gmail.com", userService.HashPassword("d@gmail.com", "12345"), "D");
            userService.CreateJudgePairs();
            var judgePairs = service.GetAllJudgePairs();
            Assert.AreEqual(2, judgePairs.Count());
            var pair1 = judgePairs[0];
            var pair2 = judgePairs[1];

            // School
            var school = service.CreateSchool(eventID, "s@gmail.com", userService.HashPassword("s@gmail.com", "12345"), "Business College Syd");

            // Teams 
            service.CreateTeam("EasyOn", school.FldSchoolId, "Trade and Skills");
            service.CreateTeam("Two", school.FldSchoolId, "Trade and Skills");

            // Questions (already setup)
            var questions = service.GetAllQuestions();
            var question1 = questions[0];

            // Do
            var voteModel = new CreateVoteModel()
            {
                FldJudgeUsername = service.GetJudgeByID(pair1.FldJudgeIda).FldJudgeUsername,
                FldPoints = 10,
                FldQuestionModifier = question1.FldQuestionModifier,  // todo remove
                FldQuestiontext = question1.FldQuestionText,
                FldTeamName = "EasyOn"
            };
            service.Vote(voteModel);
            
            // Assertions
            var vote1 = service.FindJudgePairVotes(question1.FldQuestionId, pair1.FldJudgePairId, "EasyOn");
            Assert.IsNotNull(vote1);
            Assert.AreEqual(10, vote1.FldPoints);

            // Revote
            voteModel.FldPoints = 5;
            service.Vote(voteModel);

            // Assertions
            var vote2 = service.FindJudgePairVotes(question1.FldQuestionId, pair1.FldJudgePairId, "EasyOn");
            Assert.IsNotNull(vote2);
            Assert.AreEqual(5, vote2.FldPoints);
        }

        [TestMethod]
        public void FindQuestionAndVotes()
        {
            service = new DatabaseService();

            List<TblVoteAnswer> voteAnswer = service.FindQuestionsAndVotes("report", "Trade and Skills", 1, "TeamNavn_One");
            Assert.AreEqual(2, voteAnswer.Count);
            Assert.AreEqual(1, voteAnswer.Where(a => a.Points == 0).Count());
            Assert.AreEqual(1, voteAnswer.Where(a => a.Points == 2).Count());
        }
    }
}
