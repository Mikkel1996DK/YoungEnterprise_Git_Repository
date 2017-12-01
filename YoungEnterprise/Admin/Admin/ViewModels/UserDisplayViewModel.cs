using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service;

namespace Admin.ViewModels
{
    public class UserDisplayViewModel : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private DatabaseService dbService = null;

        private ObservableCollection<Service.Models.User> users = new ObservableCollection<Service.Models.User>();
        public ObservableCollection<Service.Models.User> Users
        {
            get { return users; }
            set { users = value; }
        }


        public UserDisplayViewModel()
        {
            dbService = new DatabaseService();

            users = ConvertToObservableCollection(dbService.GetUsers());
        }

        private ObservableCollection<Service.Models.User> ConvertToObservableCollection (IEnumerable<Service.Models.User> list)
        {
            ObservableCollection<Service.Models.User> collection = new ObservableCollection<Service.Models.User>();
            foreach(Service.Models.User listItem in list)
            {
                collection.Add(listItem);
            }

            return collection;
        }

        public void ChangeSelection (string selection)
        {
            Console.WriteLine(selection);

            if (selection == "Skoler")
            {
                users.Clear();

                foreach (Service.Models.User user in ConvertToObservableCollection(dbService.GetUsers().FindAll(n => n.isSchool == true)))
                {
                    users.Add(user);
                }

            } else if (selection == "Dommere")
            {
                users.Clear();

                foreach (Service.Models.User user in ConvertToObservableCollection(dbService.GetUsers().FindAll(n => n.isSchool == false)))
                {
                    users.Add(user);
                }

            } else if (selection == "Alle")
            {
                users.Clear();

                foreach (Service.Models.User user in ConvertToObservableCollection(dbService.GetUsers()))
                {
                    users.Add(user);
                }

            }
        }
    }
}
