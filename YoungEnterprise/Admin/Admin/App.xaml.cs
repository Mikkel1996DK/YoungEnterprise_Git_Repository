using System;
using System.Windows;

namespace Admin
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            if (e.Exception is ApplicationException)
            {
                Console.WriteLine(e.Exception.StackTrace);
                MessageBox.Show(e.Exception.Message, "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Console.WriteLine(e.Exception.StackTrace);
                MessageBox.Show("Øv, Der skete en fejl - Kontakt din administrator", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            e.Handled = true;
        }
    }
}
