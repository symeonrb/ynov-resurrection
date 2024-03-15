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
            sideMenuPage.Navigate(new SideMenuPage());
        }

        private void Accueil_Click(object sender, RoutedEventArgs e)
        {
            sideMenuPage.Navigate(new SideMenuPage());
        }
    }
}
