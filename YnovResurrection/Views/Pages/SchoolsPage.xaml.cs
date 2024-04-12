using System.Windows;
using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages;

public partial class SchoolsPage : Page
{
    public SchoolsPage()
    {
        InitializeComponent();

        // Définir le DataContext de la page sur lui-même (this)
        ListModels.ItemsSource = SchoolService.Instance.List();
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        // Obtenez le bouton qui a déclenché l'événement
        Button? button = sender as Button;

        // Obtenez l'élément (Course) associé à la ligne sur laquelle le bouton a été cliqué
        Course? course = button?.DataContext as Course;

        // Obtenez la source de données du DataGrid et
        // Supprimez l'élément de votre liste de données
        if (ListModels.ItemsSource is List<Course> itemsSource)
        {
            itemsSource.Remove(course!);

            // Rafraîchissez l'affichage du DataGrid
            ListModels.Items.Refresh();
        }
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        // Obtenez le bouton qui a déclenché l'événement
        Button button = (Button)sender;

        // Obtenez l'élément (Course) associé à la ligne sur laquelle le bouton a été cliqué
        School school = (School)button.DataContext;

        // Créer une instance de la page de l'édition du bâtiment en passant le bâtiment sélectionné en paramètre

        SchoolPageViewModel viewModel = new(school)
        {
            Page = this,
            IsEditMode = true
        };
        SchoolPage coursePage = new(viewModel);

        // Naviguer vers la page de l'édition du bâtiment
        NavigationService.Navigate(coursePage);
    }
}
