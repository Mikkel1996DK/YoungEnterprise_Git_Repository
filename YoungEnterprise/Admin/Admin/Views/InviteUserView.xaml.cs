using Admin.ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Admin.Views
{
    /// <summary>
    /// Interaction logic for InviteUserView.xaml
    /// </summary>
    public partial class InviteUserView : UserControl
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private InviteUserViewModel inviteUserViewModel = new InviteUserViewModel();

        public InviteUserView()
        {
            InitializeComponent();
            DataContext = inviteUserViewModel;
        }
                
        // A simple method that should run on click of the Send Invite button
        private void SendEmail(object sender, RoutedEventArgs e)
        {
            inviteUserViewModel.InviteUser();
        }
    }
}
