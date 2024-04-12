using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour BuildingPage.xaml
    /// </summary>
    public partial class CoursePage : Page
    {
        public CoursePage(CoursePageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Code pour save en BDD
            // TODO

            // Revenir à la page précédente
            NavigationService?.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Code pour save en BDD
            // TODO

            // Convertir le DataContext en instance de votre ViewModel
            if (DataContext is CoursePageViewModel viewModel)
            {
                // Restaurer les valeurs du Course original
                viewModel.Model.Module = viewModel.ModelCopy.Module;
                viewModel.Model.StartTime = viewModel.ModelCopy.StartTime;
                viewModel.Model.EndTime = viewModel.ModelCopy.EndTime;
                viewModel.Model.IsRemote = viewModel.ModelCopy.IsRemote;
                viewModel.Model.Room = viewModel.ModelCopy.Room;
                viewModel.Page.ListModels.Items.Refresh();
            }

            // Revenir à la page précédente
            NavigationService?.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Revenir à la page précédente
            NavigationService?.GoBack();
        }
    }
}
