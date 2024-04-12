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
            BuildingPageViewModel viewModel =
                new(BuildingService.Instance.CreateBuilding(address: "Entrez ici l'adresse du bâtiment",
                    school: SchoolService.Instance.List().First()))
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
            if (listBuildings.ItemsSource is List<Building> itemsSource)
            {
                itemsSource.Remove(building!);

                // Rafraîchissez l'affichage du DataGrid
                listBuildings.Items.Refresh();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            // Obtenez le bouton qui a déclenché l'événement
            Button button = (Button)sender;

            // Obtenez l'élément (Building) associé à la ligne sur laquelle le bouton a été cliqué
            Building building = (Building)button.DataContext;

            // Créer une instance de la page de l'édition du bâtiment en passant le bâtiment sélectionné en paramètre
            
            BuildingPageViewModel viewModel = new(building)
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
