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
            Assert.IsFalse(LoginUser("WrongUsername", service.HashPassword("WrongUsername", "WrongPassword")));

            // Tests if the user can log in with wrong username and right password
            // Should return false
            Assert.IsFalse(LoginUser("WrongUsername", service.HashPassword("WrongUsername", "ActualPassword")));

            // Tests if the user can login with the right username and the wrong password
            // Should return false
            Assert.IsFalse(LoginUser("ActualUsername", service.HashPassword("ActualUsername", "WrongPassword")));

            // Tests if the user can login with the right usernae and the right password
            // Should return true.
            Assert.IsTrue(LoginUser("ActualUsername", service.HashPassword("ActualUsername", "ActualPassword")));
        }
    }
}
