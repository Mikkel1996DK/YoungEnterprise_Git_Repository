using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Service.Models
{
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string name;
        public string Name
        {
            get { return name; }
            set {
                name = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Name"));
            }
        }

        private string userName;
        public string UserName
        {
            get { return userName; }
            set {
                userName = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("UserName"));

            }
        }

        public bool isSchool;

        public User(bool isSchool)
        {
            this.isSchool = isSchool;
        }

    }
}
