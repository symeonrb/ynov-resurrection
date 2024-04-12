using System.Windows.Controls;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages;

public partial class SchoolPage : Page
{
    public SchoolPage(SchoolPageViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}
