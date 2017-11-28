using System;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;

namespace Service
{
    public class EmailService
    {
        // The SmtpClient in order to send the email
        // The MailMessage to send to the recipient
        // The senderAddress in order to store the senders email to send multiple in a row.
        private SmtpClient client = null;
        private MailMessage mailMessage = null;
        public string senderAddress = "";


        public EmailService(string mailHost, int mailPort, bool enableSSL, string senderEmail, string senderPassword)
        {
            // Initialization of the smtpclient
            SetMailAddress(mailHost, mailPort, enableSSL, senderEmail, senderPassword);
        }

        // Created a method to change the email in case the administrator wants to change the email address being used
        public void SetMailAddress(string mailHost, int mailPort, bool enableSSL, string senderEmail, string senderPassword)
        {
            client = new SmtpClient(mailHost, mailPort);
            client.Host = mailHost;
            client.Port = mailPort;
            client.EnableSsl = enableSSL;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential(senderEmail, senderPassword);

            senderAddress = senderEmail;
        }

        // The reciever being the recievers email address, the title being the title of the mail and the content being the mail itself.
        public void SendInviteMail(string reciever, string title, string name, string username)
        {
            //Sends the email
            string text = "Hej " + name + "." + Environment.NewLine + Environment.NewLine + "Du er hermed inviteret til YoungEnterprise event!" + Environment.NewLine +
                          "Brugernavn: " + username + Environment.NewLine +
                          "Kodeord   : " + GetRandomPassword(8);
            mailMessage = new MailMessage(senderAddress, reciever, title, text);

            client.Send(mailMessage);

            // Sets the mailmessage to null which is the mailMessage's initial state
            mailMessage = null;
        }

        public string GetRandomPassword(int length)
        {
            //Discuss whether or not to include both upper and lowercase letters!
            string alphanumericCharacters = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

            var characters = alphanumericCharacters.Distinct().ToArray();

            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[length * 8];
            rng.GetBytes(buffer);
            char[] pass = new char[length]; 

            for (int i = 0; i < length; i++)
            {
                ulong val = BitConverter.ToUInt64(buffer, i * 8);
                pass[i] = characters[val % (uint)characters.Length];
            }

            return new string(pass);
        }


    }
}
