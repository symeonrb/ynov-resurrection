using System.Windows;
using System.Windows.Controls;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages;

public partial class SchoolPage
{
    public SchoolPage(SchoolPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not SchoolPageViewModel viewModel) return;
        SchoolService.Instance.CreateSchool(
            name: viewModel.Model.Name
        );
        viewModel.Page.ListModels.Items.Refresh();
        NavigationService?.GoBack();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not SchoolPageViewModel viewModel) return;
        SchoolService.Instance.UpdateSchool(school: viewModel.Model);
        viewModel.Page.ListModels.Items.Refresh();
        NavigationService?.GoBack();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
}
