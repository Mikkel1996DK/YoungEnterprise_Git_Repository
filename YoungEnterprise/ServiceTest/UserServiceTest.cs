using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Text;
using YoungEnterprise_API.Models;

namespace ServiceTest
{
    [TestClass]
    public class UserServiceTest
    {
        private UserService service = new UserService();

        [TestMethod]
        public void TestHashPassword()
        {
            //Expected: ed050212b5c7a07d0052be42c5f435b2b061d4ce72e4db559278bf485fe81ec4
            //Username = "TESTUSERNAME"
            //Password = "TESTPASSWORD"
            Assert.AreEqual("ed050212b5c7a07d0052be42c5f435b2b061d4ce72e4db559278bf485fe81ec4", service.HashPassword("TESTUSERNAME", "TESTPASSWORD"));
        }

        [TestMethod]
        public void TestLogin()
        {
            string wrongUsername = "madsandersenmadsen@gmail.com";
            string wrongPassword = "Tlou81tl";
            string actualUsername = "mikkelljungberg@gmail.com";
            string actualPassword = "ls99cTO9";

            // Tests if the user can log in with wrong username and password
            // Should return false
            Assert.IsFalse(service.CheckJudgeLogin(wrongUsername, service.HashPassword(wrongUsername, wrongPassword)));

            // Tests if the user can log in with wrong username and right password
            // Should return false
            Assert.IsFalse(service.CheckJudgeLogin(wrongUsername, service.HashPassword(wrongUsername, actualPassword)));

            // Tests if the user can login with the right username and the wrong password
            // Should return false
            Assert.IsFalse(service.CheckJudgeLogin(actualUsername, service.HashPassword(actualUsername, wrongPassword)));

            // Tests if the user can login with the right usernae and the right password
            // Should return true.
            Assert.IsTrue(service.CheckJudgeLogin(actualUsername, service.HashPassword(actualUsername, actualPassword)));
        }

    }
}
