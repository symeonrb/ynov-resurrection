using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour BuildingsListPage.xaml
    /// </summary>
    public partial class BuildingsListPage : Page
    {

        public BuildingsListPage()
        {
            InitializeComponent();

            // Obtenez une instance de BuildingService à partir du conteneur d'injection de dépendances
            var buildingService = (BuildingService)App.Me
                                                             .ServiceProvider
                                                             .GetService(typeof(BuildingService));

            // Créez le view model en passant l'instance de BuildingService
            var viewModel = new BuildingsListPageViewModel(buildingService!);

            // Définissez le contexte de données de la page sur le view model
            DataContext = viewModel;

            AddColumnsToDataGrid();
        }

        private void AddColumnsToDataGrid()
        {
            // Créer une liste de noms de propriétés à afficher dans les colonnes
            List<string> propertyNames = typeof(Building).GetProperties()
                                                          .Where(p => p.Name != "Id") // Exclure la propriété "Id"
                                                          .Select(p => p.Name)
                                                          .ToList();

            // Parcourir la liste des noms de propriétés et ajouter une colonne pour chaque propriété
            foreach (string propertyName in propertyNames)
            {
                // Créer une nouvelle colonne avec le nom de la propriété comme en-tête
                DataGridTextColumn column = new DataGridTextColumn();
                column.Header = propertyName;

                // Lier la colonne à la propriété correspondante dans l'objet Building
                column.Binding = new Binding(propertyName);

                // Ajouter la colonne à la DataGrid
                listBuildings.Columns.Add(column);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtenez une instance de BuildingService à partir du conteneur d'injection de dépendances
            var buildingService = (BuildingService)App.Me
                                                             .ServiceProvider
                                                             .GetService(typeof(BuildingService));

            BuildingPageViewModel viewModel =
                new(buildingService,new Building())
                {
                    Page = this,
                    IsAddMode = true
                };
            BuildingPage buildingPage = new(viewModel);

            // Naviguer vers la page de l'édition du bâtiment
            NavigationService.Navigate(buildingPage);
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtenez le bouton qui a déclenché l'événement
            Button? button = sender as Button;

            // Obtenez l'élément (Building) associé à la ligne sur laquelle le bouton a été cliqué
            Building? building = button?.DataContext as Building;

            // Obtenez la source de données du DataGrid et
            // Supprimez l'élément de votre liste de données
            if (DataContext is BuildingsListPageViewModel viewModel)
            {
                viewModel.DeleteBuilding(building);

                // Rafraîchissez l'affichage du DataGrid
                //listBuildings.Items.Refresh();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtenez le bouton qui a déclenché l'événement
            Button button = (Button)sender;

            // Obtenez l'élément (Building) associé à la ligne sur laquelle le bouton a été cliqué
            Building building = (Building)button.DataContext;

            // Obtenez une instance de BuildingService à partir du conteneur d'injection de dépendances
            var buildingService = (BuildingService)App.Me
                                                             .ServiceProvider
                                                             .GetService(typeof(BuildingService));

            // Créer une instance de la page de l'édition du bâtiment en passant le bâtiment sélectionné en paramètre

            BuildingPageViewModel viewModel = new(buildingService,building)
            {
                Page = this,
                IsEditMode = true
            };
            BuildingPage buildingPage = new(viewModel);

            // Naviguer vers la page de l'édition du bâtiment
            NavigationService.Navigate(buildingPage);
        }
    }
}
