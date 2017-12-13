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
using Admin.ViewModels;

namespace Admin.Views
{
    /// <summary>
    /// Interaction logic for ResultView.xaml
    /// </summary>
    public partial class ResultView : UserControl
    {
        private ResultViewModel viewModel = new ResultViewModel();
        public ResultView()
        {
            InitializeComponent();
            DataContext = viewModel;
        }



        private void categoryCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            viewModel.ChangeSelection((categoryCombo.SelectedValue as ComboBoxItem).Content.ToString());
        }
    }
}
