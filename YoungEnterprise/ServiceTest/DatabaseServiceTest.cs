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
           
            int number = service.GetAllJudges().Count;

            Assert.AreEqual(number, service.GetAllJudges().Count);
            service.CreateJudge(1, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            // As we have now added a judge, the expected number is one more than before
            Assert.AreEqual(number + 1, service.GetAllJudges().Count);
        }

        public void CreateSchoolTest()
        {
            service = new DatabaseService();
 
            int number = service.GetAllSchool().Count;

            Assert.AreEqual(number, service.GetSchool().Count);
            service.CreateSchool(1, "louisebc@gmail.com", userService.HashPassword("louisebc@gmail.com", "12345"), "Louise");
            // As we have now added a school, the expected number is one more than before
            Assert.AreEqual(number + 1, service.GetAllJudges().Count);
        }
    }
}
