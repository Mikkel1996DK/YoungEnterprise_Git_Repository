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
    }
}
