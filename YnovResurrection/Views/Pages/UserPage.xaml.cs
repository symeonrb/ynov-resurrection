using System.Windows;
using System.Windows.Controls;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages;

public partial class UserPage : Page
{
    public UserPage(UserPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not UserPageViewModel viewModel) return;
        UserService.Instance.CreateUser(
            firstName: viewModel.Model.FirstName,
            studentGroups: viewModel.Model.StudentGroups
        );
        viewModel.Page.ListModels.Items.Refresh();
        NavigationService?.GoBack();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not UserPageViewModel viewModel) return;
        UserService.Instance.UpdateUser(user: viewModel.Model);
        viewModel.Page.ListModels.Items.Refresh();
        NavigationService?.GoBack();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
}
