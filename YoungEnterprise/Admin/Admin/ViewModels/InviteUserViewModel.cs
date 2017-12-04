using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.ViewModels
{
    // EmailService has been outcommented in this class due to it not working on the EASV network (It crashes the application on that network).
    //  - However it works fine at Mikkel's home network.
    public class InviteUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //private EmailService mailSender = new EmailService();
        private DatabaseService dbService = new DatabaseService();
        private UserService userService = new UserService();

        private string nameText;
        public string NameText
        {
            get { return nameText; }
            set
            {
                nameText = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("NameText"));
            }
        }

        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Email"));
            }
        }

        private bool isSchool = true;
        public bool IsSchool
        {
            get { return isSchool; }
            set
            {
                isSchool = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsSchool"));
            }
        }

        public void InviteUser ()
        {
            string pw = userService.GetRandomPassword(8);

            Console.WriteLine(pw);

            if (!isSchool)
            {
                //mailSender.SendInviteMail(email, "Young Enterprise | Dommer Invitiation", nameText, email, pw);
                

                dbService = new DatabaseService();
                dbService.CreateJudge(1, email, userService.HashPassword(email, pw), nameText);
                pw = null;
            }
            else
            {
                
                //mailSender.SendInviteMail(email, "Young Enterprise | Skole Invitiation", nameText, email, pw);

                dbService = new DatabaseService();
                dbService.CreateSchool(1, email, userService.HashPassword(email, pw), nameText);
                pw = null;
            }
        }
    }
}
