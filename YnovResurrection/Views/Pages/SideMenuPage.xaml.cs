using System.Windows;
using System.Windows.Controls;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour SideMenuPage.xaml
    /// </summary>
    public partial class SideMenuPage : Page
    {
        public SideMenuPage()
        {
            InitializeComponent();
        }

        static MainWindow MainWindow { get => (MainWindow)Application.Current.MainWindow; }

        private void Schools_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.schoolsPage.Navigate(new SchoolsPage());
        }

        private void Buildings_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.buildingsPage.Navigate(new BuildingsPage());
        }
    }
}
