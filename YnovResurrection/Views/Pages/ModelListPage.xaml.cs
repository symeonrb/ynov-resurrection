using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using YnovResurrection.Models;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages;

public partial class ModelListPage : Page // where T : class, IModel, new()
{
    public ModelListPage(IModelListPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
        AddColumnsToDataGrid();
    }

    public void AddColumnsToDataGrid()
    {
        if (DataContext is not IModelListPageViewModel viewModel) return;

        // Créer une liste de noms de propriétés à afficher dans les colonnes
        List<string> propertyNames = viewModel.ModelType.GetProperties()
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
        if (DataContext is not IModelListPageViewModel viewModel) return;
        var editPage = viewModel.EditModel(this, null);
        if (editPage == null) return;
        NavigationService?.Navigate(editPage);
    }

    private void DeleteButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not IModelListPageViewModel viewModel) return;
        if ((sender as Button)?.DataContext is not IModel model) return;
        viewModel.DeleteModel(model);
        ListModels.Items.Refresh();
    }

    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not IModelListPageViewModel viewModel) return;
        if ((sender as Button)?.DataContext is not IModel model) return;
        var editPage = viewModel.EditModel(this, model);
        if (editPage == null) return;
        NavigationService?.Navigate(editPage);
    }
}
