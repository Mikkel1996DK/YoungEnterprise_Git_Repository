using Admin.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Admin
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region IMPORTANT COMMENT IN THIS REGION

        // All of the xaml "main"-grids RowDefinitions should:
        // - All should add up to 9
        // - Top two rows should be of the auto-size of 1.5* except if the usercontrol contains a DataGrid
        //   Such as the CreateScheduleControl's layout
        //   and also the ViewUsersControl's layout

        // Layout 1, with datagrid (CreateScheduleControl.xaml & ViewUsersControl.xaml)
        // ColumnDefinitions:
        // Subject to change, however they should always add up to 13, with a 0.5* autowidth in the left and the right side.
        // RowDefinitions:
        // 1.5*
        // 1*
        // 1*
        // 5.5*

        // Layout 2, without datagrid in the invite usercontrols (InviteJudgeControl.xaml, InviteSchoolControl.xaml)
        // ColumnDefinitions:
        // 1*
        // 2*
        // 1*
        // RowDefinitions:
        // 1.5*
        // 1.5*
        // 1*
        // 1*
        // 1*
        // 2*
        // 1*
        #endregion

        //private InviteUserView inviteUserControl = new InviteUserView();
        private ResultView viewResultsControl = new ResultView();
        //private UserDisplayView viewUsersControl = new UserDisplayView();
        private UserDisplayView viewUsersControl = null;
        private EventView eventView = new EventView();
        

        public MainWindow()
        {
            InitializeComponent();
            viewUsersControl = new UserDisplayView(this);
            userControlGrid.Children.Add(viewUsersControl);
        }

        // Shifts a usercontrol with another usercontrol
        public void ShiftUserControl(Control userControl)
        {
            userControlGrid.Children.Clear();
            userControlGrid.Children.Add(userControl);
        }

        #region menuitem eventhandlers that should only run the ShiftUserControl(Control userControl) method.
        private void viewAllUsers_Click(object sender, RoutedEventArgs e)
        {
            ShiftUserControl(viewUsersControl);
        }

        private void viewResults_Click(object sender, RoutedEventArgs e)
        {
            ShiftUserControl(viewResultsControl);
        }

        private void ViewEvent_Click(object sender, RoutedEventArgs e)
        {
            ShiftUserControl(eventView);
        }
        #endregion

    }
}
