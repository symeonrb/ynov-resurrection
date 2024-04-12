using System.Windows;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour BuildingPage.xaml
    /// </summary>
    public partial class BuildingPage
    {
        public BuildingPage(BuildingPageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not BuildingPageViewModel viewModel) return;
            BuildingService.Instance.CreateBuilding(
                address: viewModel.Model.Address,
                school: viewModel.Model.School
            );
            viewModel.Page.ListModels.Items.Refresh();
            NavigationService?.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not BuildingPageViewModel viewModel) return;
            BuildingService.Instance.UpdateBuilding(building: viewModel.Model);
            viewModel.Page.ListModels.Items.Refresh();
            NavigationService?.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
    }
}
