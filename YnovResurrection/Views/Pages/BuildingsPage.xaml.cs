using System.Windows;
using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Services;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour BuildingsPage.xaml
    /// </summary>
    public partial class BuildingsPage : Page
    {
        public BuildingsPage()
        {
            InitializeComponent();

            // Définir le DataContext de la page sur lui-même (this)
            listBuildings.ItemsSource = BuildingService.Instance.List();
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
            Button? button = sender as Button;

            // Obtenez l'élément (Building) associé à la ligne sur laquelle le bouton a été cliqué
            Building? building = button?.DataContext as Building;

            // Naviguez dans la page d'édition de formulaire
        }
    }
}
