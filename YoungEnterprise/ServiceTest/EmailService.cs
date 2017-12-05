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

        #region in this region: smtp server, port, ssl, user/pass etc.
        // DO NOT DELETE COMMENTS BELOW THIS COMMENT:
        // gmail smtp server: smtp.gmail.com
        // port: 587
        // ssl: enable SSL
        // user: youngenterprise.mail1379@gmail.com
        // pass: yprise987
        #endregion

        public EmailService()
        {
            // Initialization of the smtpclient
            SetMailAddress("smtp.gmail.com", 587, true, "youngenterprise.mail1379@gmail.com", "yprise987");
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
        public void SendInviteMail(string reciever, string title, string name, string username, string password)
        {
            //Sends the email
            string text = "Hej " + name + "." + Environment.NewLine + Environment.NewLine + "Du er hermed inviteret til YoungEnterprise event!" + Environment.NewLine +
                          "Brugernavn: " + username + Environment.NewLine +
                          "Kodeord   : " + password;
            mailMessage = new MailMessage(senderAddress, reciever, title, text);

            client.Send(mailMessage);

            // Sets the mailmessage to null which is the mailMessage's initial state
            mailMessage = null;
        }
    }
}
