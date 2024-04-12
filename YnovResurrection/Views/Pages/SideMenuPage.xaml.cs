using System.Windows;
using System.Windows.Controls;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour SideMenuPage.xaml
    /// </summary>
    public partial class SideMenuPage : Page
    {
        private static MainWindow MainWindow { get => (MainWindow)Application.Current.MainWindow; }

        public SideMenuPage()
        {
            InitializeComponent();
        }

        private void Schools_Click(object sender, RoutedEventArgs e)
        {
            DataListPage page = new(new SchoolsListPageViewModel());
            MainWindow.MainPage.Navigate(page);
        }

        private void Buildings_Click(object sender, RoutedEventArgs e)
        {
            DataListPage page = new(new BuildingsListPageViewModel());
            MainWindow.MainPage.Navigate(page);
        }

        private void Courses_Click(object sender, RoutedEventArgs e)
        {
            Page page = new CoursesListPage();
            CoursesListPageViewModel viewModel = new();
            page.DataContext = viewModel;
            MainWindow.MainPage.Navigate(page);
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
