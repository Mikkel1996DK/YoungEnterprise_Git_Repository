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

            Assert.AreEqual(number, service.GetAllJudges().Count);
            service.CreateJudge(1, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            // As we have now added a judge, the expected number is three
            Assert.AreEqual(number + 1, service.GetAllJudges().Count);
        }
    }
}
