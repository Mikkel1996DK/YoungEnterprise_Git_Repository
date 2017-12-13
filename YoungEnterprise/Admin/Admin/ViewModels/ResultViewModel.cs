using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Service;

namespace Admin.ViewModels
{
    public class ResultViewModel
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private DatabaseService dbService = null;

        private ObservableCollection<Service.Models.TeamResultModel> teamResults = new ObservableCollection<Service.Models.TeamResultModel>();
        public ObservableCollection<Service.Models.TeamResultModel> TeamResults
        {
            get { return teamResults; }
            set { teamResults = value; }
        }

        public ResultViewModel()
        {
            dbService = new DatabaseService();
            ShowAll();
        }

        private ObservableCollection<Service.Models.TeamResultModel> ConvertToObservableCollection(IEnumerable<Service.Models.TeamResultModel> list)
        {
            ObservableCollection<Service.Models.TeamResultModel> collection = new ObservableCollection<Service.Models.TeamResultModel>();
            foreach (Service.Models.TeamResultModel listItem in list)
            {
                collection.Add(listItem);
            }

            return collection;
        }

        public void ChangeSelection(string selection)
        {
            Console.WriteLine(selection);

            if (selection == "Alle") ShowAll();
            else if (selection == "Trade and Skills") ShowTradeAndSkills();
            else if (selection == "Globalization and Society") ShowGlobalizationAndSociety();
            else if (selection == "Science and Technology") ShowScienceAndTechnology();
            else if (selection == "Business and Services") ShowBusinessAndService();
        }

        private void ShowAll()
        {
            teamResults.Clear();

            foreach (Service.Models.TeamResultModel teamResult in ConvertToObservableCollection(dbService.FindTeamResults()))
            {
                teamResults.Add(teamResult);
            }
        }

        private void ShowTradeAndSkills()
        {
            teamResults.Clear();

            foreach (Service.Models.TeamResultModel teamResult in ConvertToObservableCollection(dbService.FindTeamResults().FindAll(n => n.Subject == "Trade and Skills")))
            {
                teamResults.Add(teamResult);
            }
        }

        private void ShowGlobalizationAndSociety()
        {
            teamResults.Clear();

            foreach (Service.Models.TeamResultModel teamResult in ConvertToObservableCollection(dbService.FindTeamResults().FindAll(n => n.Subject == "Globalization and Society")))
            {
                teamResults.Add(teamResult);
            }
        }
        private void ShowScienceAndTechnology()
        {
            teamResults.Clear();

            foreach (Service.Models.TeamResultModel teamResult in ConvertToObservableCollection(dbService.FindTeamResults().FindAll(n => n.Subject == "Science and Technology")))
            {
                teamResults.Add(teamResult);
            }
        }

        private void ShowBusinessAndService()
        {
            teamResults.Clear();

            foreach (Service.Models.TeamResultModel teamResult in ConvertToObservableCollection(dbService.FindTeamResults().FindAll(n => n.Subject == "Business and Service")))
            {
                teamResults.Add(teamResult);
            }
        }
    }
}



