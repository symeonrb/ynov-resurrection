using System.Windows;
using System.Windows.Controls;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages;

public partial class RoomPage : Page
{
    public RoomPage(RoomPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not RoomPageViewModel viewModel) return;
        RoomService.Instance.CreateRoom(
            building: viewModel.Model.Building,
            name: viewModel.Model.Name,
            location: viewModel.Model.Location,
            accessibility: viewModel.Model.Accessibility
        );
        viewModel.Page.ListModels.Items.Refresh();
        NavigationService?.GoBack();
    }

    private void SaveButton_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is not RoomPageViewModel viewModel) return;
        RoomService.Instance.UpdateRoom(room: viewModel.Model);
        viewModel.Page.ListModels.Items.Refresh();
        NavigationService?.GoBack();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
}
