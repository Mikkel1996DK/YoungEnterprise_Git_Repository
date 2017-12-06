using Service;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YoungEnterprise_API.Models;

namespace Admin.ViewModels
{
    public class EventViewModel : INotifyCollectionChanged
    {
        public event NotifyCollectionChangedEventHandler CollectionChanged;

        private DatabaseService dbService = new DatabaseService();
        private UserService userService = new UserService();

        private ObservableCollection<DisplayJudgePair> judgePairs = new ObservableCollection<DisplayJudgePair>();
        public ObservableCollection<DisplayJudgePair> JudgePairs
        {
            get { return judgePairs; }
            set { judgePairs = value; }
        }


        public EventViewModel()
        {
            RefreshCollections();
        }

        // Used for the "Lav Dommerpar" button.
        // 1: Shift to judge datagrid
        // 2: Use the method in Userservice.
        // 3: Update datagrid
        public void CreateJudgePairs ()
        {
            userService.CreateJudgePairs();

        }

        public void RefreshCollections ()
        {
            judgePairs.Clear();

            List<TblJudgePair> pairs = dbService.GetAllJudgePairs();
            List<TblJudge> judges = dbService.GetAllJudges();

            foreach (TblJudgePair pair in pairs)
            {
                DisplayJudgePair displayPair = new DisplayJudgePair();
                displayPair.JudgePairID = pair.FldJudgePairId;

                displayPair.JudgeNameA = judges.Find(n => n.FldJudgeId == pair.FldJudgeIda).FldJudgeName;
                displayPair.JudgeNameB = judges.Find(n => n.FldJudgeId == pair.FldJudgeIdb).FldJudgeName;

                judgePairs.Add(displayPair);
            }

            // Initialize ScheduleCollection here when completed!.
        }


        // Prompt for ok/cancel with a warning
        // Clear the database
        // Add a new event with the date from the datepicker
        public void NewEvent (DateTime dateTime)
        {
            string text = "Dette sletter alt indehold i databasen!" + Environment.NewLine + "Vil du fortsætte?";
            MessageBoxResult result = MessageBox.Show(text, "Advarsel!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                dbService.DeleteAllRecords();
                dbService.CreateEvent(dateTime);
            }
        }

    }
}
