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

        private void Buildings_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.buildingsPage.Navigate(new BuildingsPage());
        }

        private void Menu2_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new MainMenu());
        }

        private void Menu3_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new MainMenu());
        }

        private void Menu4_Click(object sender, RoutedEventArgs e)
        {
            //mainFrame.Navigate(new MainMenu());
        }
    }
}
