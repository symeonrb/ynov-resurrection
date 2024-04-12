using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour CoursePage.xaml
    /// </summary>
    public partial class CoursePage : Page
    {
        public CoursePage(CoursePageViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not CoursePageViewModel viewModel) return;
            CourseService.Instance.CreateCourse(
                module: viewModel.ModelCopy.Module,
                startTime: viewModel.ModelCopy.StartTime,
                endTime: viewModel.ModelCopy.EndTime,
                isRemote: viewModel.ModelCopy.IsRemote
            );
            viewModel.Page.ListModels.Items.Refresh();
            NavigationService?.GoBack();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not CoursePageViewModel viewModel) return;
            CourseService.Instance.UpdateCourse(course: viewModel.ModelCopy);
            viewModel.Page.ListModels.Items.Refresh();
            NavigationService?.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
    }
}
