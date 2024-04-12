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
            // Code pour save en BDD
            // TODO

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
                // Restaurer les valeurs du Building original
                viewModel.Building.Address = viewModel.BuildingCopy.Address;
                viewModel.Building.School = viewModel.BuildingCopy.School;
                viewModel.Page.listBuildings.Items.Refresh();
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
