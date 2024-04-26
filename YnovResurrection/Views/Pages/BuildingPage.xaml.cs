using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour BuildingPage.xaml
    /// </summary>
    public partial class BuildingPage : Page
    {
        public BuildingPage(BuildingPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is BuildingPageViewModel viewModel)
            {
                viewModel.AddBuilding();
                //viewModel.Page.listBuildings.Items.Refresh();
            }

            // Revenir à la page précédente
            NavigationService.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Code pour save en BDD
            // TODO

            // Convertir le DataContext en instance de votre ViewModel
            if (DataContext is BuildingPageViewModel viewModel)
            {
                viewModel.SaveBuilding();
            }

            // Revenir à la page précédente
            NavigationService.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Revenir à la page précédente
            NavigationService.GoBack();
        }
    }
}
