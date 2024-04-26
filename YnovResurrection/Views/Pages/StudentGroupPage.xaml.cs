using System.Windows;
using System.Windows.Controls;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages;

public partial class StudentGroupPage : Page
{
    public StudentGroupPage(StudentGroupPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not StudentGroupPageViewModel viewModel) return;
        StudentGroupService.Instance.CreateStudentGroup(
            name: viewModel.Model.Name,
            school: viewModel.Model.School
        );
        viewModel.Page.ListModels.Items.Refresh();
        NavigationService?.GoBack();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not StudentGroupPageViewModel viewModel) return;
        StudentGroupService.Instance.UpdateStudentGroup(studentGroup: viewModel.Model);
        viewModel.Page.ListModels.Items.Refresh();
        NavigationService?.GoBack();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
}
