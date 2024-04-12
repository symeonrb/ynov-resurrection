using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YnovResurrection.Models;
using YnovResurrection.Services;
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
            if (DataContext is not BuildingPageViewModel viewModel) return;
            BuildingService.Instance.CreateBuilding(
                address: viewModel.BuildingCopy.Address,
                school: viewModel.BuildingCopy.School
            );
            viewModel.Page.ListModels.Items.Refresh();
            NavigationService?.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not BuildingPageViewModel viewModel) return;
            BuildingService.Instance.UpdateBuilding(building: viewModel.BuildingCopy);
            viewModel.Page.ListModels.Items.Refresh();
            NavigationService?.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Revenir à la page précédente
            NavigationService.GoBack();
        }
    }
}
