using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Admin.Views
{
    /// <summary>
    /// Interaction logic for InviteUserView.xaml
    /// </summary>
    public partial class InviteUserView : UserControl
    {
        public InviteUserView()
        {
            InitializeComponent();
            DataContext = this;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        // The test we will be doing for this one is just to check if the user has been added to the database when time comes to that.
        // It is not worth to make a test to check if an email has been send, as it would require us to send the
        // email async just to run the test (which is not what we want to do)

        

        private EmailService mailSender = null;
        private UserService userService = null;

        // A simple method that should run on click of the Send Invite button
        private void SendEmail(object sender, RoutedEventArgs e)
        {
            // DO NOT DELETE COMMENTS BELOW THIS COMMENT:
            // gmail smtp server: smtp.gmail.com
            // port: 587
            // ssl: enable SSL
            // user: youngenterprise.mail1379@gmail.com
            // pass: yprise987
            mailSender = new EmailService("smtp.gmail.com", 587, true, "youngenterprise.mail1379@gmail.com", "yprise987");

            if (isSchool)
            {
                SendSchoolEmail();
            }
            else
            {
                SendJudgeEmail();
                userService.
            }
        }

        // A method to send a judge email (as the content of the mail needs to be different from the school email)
        private void SendJudgeEmail()
        {
            mailSender.SendInviteMail(email, "Young Enterprise | Dommer Invitiation", nameText, email);
            mailSender = null;
        }

        // A method to send a school email (as the content of the mail needs to be different from the judge email)
        private void SendSchoolEmail()
        {
            mailSender.SendInviteMail(email, "Young Enterprise | Skole Invitiation", nameText, email);
            mailSender = null;
        }
    }
}
