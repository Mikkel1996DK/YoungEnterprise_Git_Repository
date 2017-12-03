﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using YoungEnterprise_API.Models;
using System.Linq;

namespace ServiceTest
{
    [TestClass]
    public class DatabaseServiceTest
    {

        private DatabaseService service;
        private UserService userService = new UserService();

        [TestMethod]
        public void CreateJudgeTest()
        {
            service = new DatabaseService();
           
            int number = service.GetAllJudges().Count;

            Assert.AreEqual(number, service.GetAllJudges().Count);
            service.CreateJudge(1, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            // As we have now added a judge, the expected number is one more than before
            Assert.AreEqual(number + 1, service.GetAllJudges().Count);
        }

        [TestMethod]
        public void CreateSchoolTest()
        {
            service = new DatabaseService();
 
            int number = service.GetAllSchools().Count;

            Assert.AreEqual(number, service.GetAllSchools().Count);
            service.CreateSchool(1, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            // As we have now added a school, the expected number is one more than before
            Assert.AreEqual(number + 1, service.GetAllSchools().Count);
        }

        [TestMethod]
        public void FindQuestionAndVotes()
        {
            service = new DatabaseService();

            List<TblVoteAnswer> voteAnswer = service.FindQuestionsAndVotes("Trade and Skills", 1, "TeamNavn_One");
            Assert.AreEqual(2, voteAnswer.Count);
            Assert.AreEqual(1, voteAnswer.Where(a => a.Points == 0).Count());
            Assert.AreEqual(1, voteAnswer.Where(a => a.Points == 2).Count());
        }
    }
}
