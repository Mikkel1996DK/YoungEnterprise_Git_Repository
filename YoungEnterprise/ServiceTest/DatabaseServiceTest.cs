using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

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
            // As there are two Judges two start with, we will expect two
            Assert.AreEqual(2, service.GetAllJudges().Count);
            service.CreateJudge(1, "louisebc@gmail", userService.HashPassword("louisebc@gmail", "12345"), "louise");
            Assert.AreEqual(3, service.GetAllJudges().Count);
        }
    }
}
