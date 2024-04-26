using System.Windows;
using System.Windows.Controls;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour SideMenuPage.xaml
    /// </summary>
    public partial class SideMenuPage : Page
    {
        static MainWindow MainWindow { get => (MainWindow)Application.Current.MainWindow; }

        public SideMenuPage()
        {
            InitializeComponent();
        }

        private void Buildings_Click(object sender, RoutedEventArgs e)
        {
            Page page = new BuildingsListPage();
            // TODO
            // BuildingsListPageViewModel viewModel = new(); // Ne marche plus à cause de la nécessité d'un service
            // page.DataContext = viewModel;
            MainWindow.mainPage.Navigate(page);
        }

        private void Courses_Click(object sender, RoutedEventArgs e)
        {
            Page page = new CoursesListPage();
            MainWindow.mainPage.Navigate(page);
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
