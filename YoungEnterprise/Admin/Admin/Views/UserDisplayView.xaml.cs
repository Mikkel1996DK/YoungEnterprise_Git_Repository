using Admin.ViewModels;
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
        private UserDisplayViewModel viewModel = new UserDisplayViewModel();

        public UserDisplayView()
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void userCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.ChangeSelection((userCombo.SelectedValue as ComboBoxItem).Content.ToString());
        }
    }
}
