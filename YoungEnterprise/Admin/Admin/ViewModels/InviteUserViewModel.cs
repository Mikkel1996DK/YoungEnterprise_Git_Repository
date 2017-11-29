using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Admin.ViewModels
{
    public class InviteUserViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private EmailService mailSender = new EmailService();
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

            //Console.WriteLine("cw1");

            if (!isSchool)
            {
                //mailSender.SendInviteMail(email, "Young Enterprise | Dommer Invitiation", nameText, email, pw);

                //Console.WriteLine("cw2");

                dbService = new DatabaseService();
                dbService.CreateJudge(1, email, userService.HashPassword(email, pw), nameText);
                pw = null;
            }
            else
            {
                /*
                mailSender.SendInviteMail(email, "Young Enterprise | Skole Invitiation", nameText, email);
                mailSender = null;
                */
            }
        }



    }
}
