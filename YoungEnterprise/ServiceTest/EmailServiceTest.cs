using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service;

namespace ServiceTest
{
    [TestClass]
    public class EmailServiceTest
    {
        private EmailService emailService = null;

        [TestMethod]
        public void TestRandomPassword()
        {
            emailService = new EmailService("smtp.gmail.com", 587, true, "youngenterprise.mail1379@gmail.com", "yprise987");

            string pw = emailService.GetRandomPassword(8);

            Assert.IsTrue(RandomPasswordTest(pw, 8));
        }

        private bool RandomPasswordTest(string pw, int expectedLength)
        {
            bool testPassed = false;
            string alphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            if (pw.ToCharArray().Length != expectedLength)
            {
                return false;
            }

            foreach (char pwLetter in pw.ToCharArray())
            {
                foreach (char acLetter in alphanumericCharacters.ToCharArray())
                {
                    if (pwLetter == acLetter)
                    {
                        testPassed = true;
                        break;
                    }
                    else
                    {
                        testPassed = false;
                    }
                }
            }

            return testPassed;
        }
    }
}
