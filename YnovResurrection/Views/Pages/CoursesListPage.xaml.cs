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
using System.Xml.Linq;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour CoursesListPage.xaml
    /// </summary>
    public partial class CoursesListPage : Page
    {
        public CoursesListPage()
        {
            InitializeComponent();

            AddColumnsToDataGrid();
        }

        private void AddColumnsToDataGrid()
        {
            // Créer une liste de noms de propriétés à afficher dans les colonnes
            List<string> propertyNames = typeof(Course).GetProperties()
                                                          .Where(p => p.Name != "Id") // Exclure la propriété "Id"
                                                          .Select(p => p.Name)
                                                          .ToList();

            // Parcourir la liste des noms de propriétés et ajouter une colonne pour chaque propriété
            foreach (string propertyName in propertyNames)
            {
                // Créer une nouvelle colonne avec le nom de la propriété comme en-tête
                DataGridTextColumn column = new()
                {
                    Header = propertyName,

                    // Lier la colonne à la propriété correspondante
                    Binding = new Binding(propertyName)
                };

                // Ajouter la colonne à la DataGrid
                ListModels.Columns.Add(column);
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            CoursePageViewModel viewModel = new(
                CourseService.Instance.CreateCourse(
                    module: ModuleService.Instance.List().First(),
                    startTime: new DateTime(),
                    endTime: new DateTime()
                )
            )
            {
                Page = this,
                IsAddMode = true
            };
            CoursePage coursePage = new(viewModel);

            // Naviguer vers la page de l'édition du bâtiment
            NavigationService.Navigate(coursePage);
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
            Course course = (Course)button.DataContext;

            // Créer une instance de la page de l'édition du bâtiment en passant le bâtiment sélectionné en paramètre

            CoursePageViewModel viewModel = new(course)
            {
                Page = this,
                IsEditMode = true
            };
            CoursePage coursePage = new(viewModel);

            // Naviguer vers la page de l'édition du bâtiment
            NavigationService.Navigate(coursePage);
        }
    }
}
