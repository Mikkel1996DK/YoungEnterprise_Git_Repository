using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Service;
using Service.Models;

namespace Admin.ViewModels
{
    public class UserDisplayViewModel : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private DatabaseService dbService = new DatabaseService();

        private ObservableCollection<User> users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get { return users; }
            set { users = value; }
        }

        public UserDisplayViewModel()
        {
            //ShowAll();
        }

        private ObservableCollection<User> ConvertToObservableCollection (IEnumerable<User> list)
        {
            ObservableCollection<User> collection = new ObservableCollection<User>();
            foreach(User listItem in list)
            {
                collection.Add(listItem);
            }

            return collection;
        }

        public void ChangeSelection (string selection)
        {
            Console.WriteLine(selection);

            if (selection == "Skoler") ShowSchools();
            else if (selection == "Dommere") ShowJudges();
            else if (selection == "Alle") ShowAll();
        }

        private void ShowAll ()
        {
            users.Clear();

            foreach (User user in ConvertToObservableCollection(dbService.GetUsers()))
            {
                users.Add(user);
            }
        }

        public void DeleteUser(User user)
        {
            if (user.isSchool)
            {
                dbService.DeleteSchool(dbService.FindSchoolFromUser(user));
            }
            else
            {
                dbService.DeleteJudge(dbService.FindJudgeFromUser(user));
            }
        }

        private void ShowSchools ()
        {
            users.Clear();

            foreach (User user in ConvertToObservableCollection(dbService.GetUsers().FindAll(n => n.isSchool == true)))
            {
                users.Add(user);
            }
        }

        private void ShowJudges ()
        {
            users.Clear();

            foreach (User user in ConvertToObservableCollection(dbService.GetUsers().FindAll(n => n.isSchool == false)))
            {
                users.Add(user);
            }
        }
    }
}
