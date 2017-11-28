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

    }
}
