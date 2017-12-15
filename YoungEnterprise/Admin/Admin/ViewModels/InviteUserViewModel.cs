using Service;
using System;
using System.ComponentModel;
using System.Windows;

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

        #region databinded variables inside this region!!
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
        #endregion

        public void InviteUser ()
        {
            string pw = userService.GetRandomPassword(8);

            Console.WriteLine(pw);

            if (!isSchool)
            {
                try
                {
                    //mailSender.SendInviteMail(email, "Young Enterprise | Dommer Invitiation", nameText, email, pw);
                    dbService.CreateJudge(dbService.GetCurrentEvent().FldEventId, email, userService.HashPassword(email, pw), nameText);
                    MessageBox.Show("Dommer Tilføjet!");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Kunne ikke oprette dommmer fordi dommeren allerede eksisterer i systemet!", "Oprettelses Fejl");
                }

                pw = null;
            }
            else
            {
                try
                {
                    //mailSender.SendInviteMail(email, "Young Enterprise | Skole Invitiation", nameText, email, pw);
                    dbService.CreateSchool(dbService.GetCurrentEvent().FldEventId, email, userService.HashPassword(email, pw), nameText);
                    MessageBox.Show("Skole Tilføjet!");
                }
                catch (Exception e)
                {
                    MessageBox.Show("Kunne ikke oprette skole fordi skolen allerede eksisterer i systemet!", "Oprettelses Fejl");
                }
                pw = null;
            }
        }
    }
}
