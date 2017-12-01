using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using YoungEnterprise_API.Models;

namespace Admin.Views
{
    /// <summary>
    /// Interaction logic for UserDisplayView.xaml
    /// </summary>
    public partial class UserDisplayView : UserControl
    {
        private ObservableCollection<TblJudge> judgeList = new ObservableCollection<TblJudge>();
        public ObservableCollection<TblJudge> JudgeList { get { return judgeList; } }


        private ObservableCollection<TblSchool> schoolList = new ObservableCollection<TblSchool>();
        public ObservableCollection<TblSchool> SudgeList { get { return schoolList; } }

        public UserDisplayView()
        {
            InitializeComponent();
        }

        private void addBruger_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (userCombo.SelectedItem.ToString().Equals("Schools")){

            }
            else if (userCombo.SelectedItem.ToString().Equals("Judges"))
            {

            }
            
        }
    }


}
