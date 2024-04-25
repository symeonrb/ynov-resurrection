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
            SideMenuPage.Navigate(new SideMenuPage());

            MainPage.NavigationService.Navigate(new LoginPage());
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            SideMenuPage.Navigate(new SideMenuPage());
        }
    }
}
