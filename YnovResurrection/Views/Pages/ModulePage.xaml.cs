using System.Windows;
using System.Windows.Controls;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages;

public partial class ModulePage : Page
{
    public ModulePage(ModulePageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not ModulePageViewModel viewModel) return;
        ModuleService.Instance.CreateModule(
            school: viewModel.Model.School,
            name: viewModel.Model.Name,
            totalHours: viewModel.Model.TotalHours,
            teacher: viewModel.Model.Teacher,
            studentGroup: viewModel.Model.StudentGroup,
            neededEquipments: viewModel.Model.NeededEquipment,
            isRemote: viewModel.Model.IsRemote,
            allowSharedRoom: viewModel.Model.AllowSharedRoom
        );
        viewModel.Page.ListModels.Items.Refresh();
        NavigationService?.GoBack();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not ModulePageViewModel viewModel) return;
        ModuleService.Instance.UpdateModule(module: viewModel.Model);
        viewModel.Page.ListModels.Items.Refresh();
        NavigationService?.GoBack();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
}
