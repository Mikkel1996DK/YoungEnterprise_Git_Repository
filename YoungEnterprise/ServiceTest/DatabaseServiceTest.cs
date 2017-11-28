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
            int number = service.GetAllJudges().Count;
            Assert.AreEqual(2, service.GetAllJudges().Count);
            service.CreateJudge(1, "louisebc@gmail", "12345", "louise");
            // As we have now added a judge, the expected number is three
            Assert.AreEqual(3, service.GetAllJudges().Count);
        }
    }
}
