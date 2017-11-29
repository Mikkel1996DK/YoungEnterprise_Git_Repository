using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;
using System;
using System.Collections.Generic;
using System.Text;

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
            // Tests if the user can log in with wrong username and password
            // Should return false
            Assert.IsFalse(LoginUser("WrongUsername1", service.HashPassword("WrongUsername1", "WrongPassword1"));

            // Tests if the user can log in with wrong username and right password
            // Should return false
            Assert.IsFalse(LoginUser("WrongUsername2", service.HashPassword("WrongUsername2", "ActualPassword2")));

            // Tests if the user can login with the right username and the wrong password
            // Should return false
            Assert.IsFalse(LoginUser("ActualUsername3", service.HashPassword("ActualUsername3", "WrongPassword3")));

            // Tests if the user can login with the right usernae and the right password
            // Should return true.
            Assert.IsTrue(LoginUser("ActualUsername4", service.HashPassword("ActualUsername4", "ActualPassword4")));
        }
    }
}
