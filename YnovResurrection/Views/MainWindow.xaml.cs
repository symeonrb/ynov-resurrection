using System.Windows;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.Views
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MainPage.NavigationService.Navigate(new LoginPage());
        }

    }
}
