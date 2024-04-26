using System.Windows;
using YnovResurrection.Services;
using YnovResurrection.ViewModels.Pages;

namespace YnovResurrection.Views.Pages
{
    /// <summary>
    /// Logique d'interaction pour CoursePage.xaml
    /// </summary>
    public partial class CoursePage
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
                module: viewModel.Model.Module,
                startTime: viewModel.Model.StartTime,
                endTime: viewModel.Model.EndTime,
                isRemote: viewModel.Model.IsRemote,
                room: viewModel.Model.Room
            );
            viewModel.Page.ListModels.Items.Refresh();
            NavigationService?.GoBack();
        }

        private void AssignRoomButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not CoursePageViewModel viewModel) return;
            try
            {
                CourseService.Instance.AssignRoomToCourse(viewModel.Model);
            }
            catch (Exception error)
            {
                Console.Write(error);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (DataContext is not CoursePageViewModel viewModel) return;
            CourseService.Instance.UpdateCourse(course: viewModel.Model);
            viewModel.Page.ListModels.Items.Refresh();
            NavigationService?.GoBack();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e) => NavigationService?.GoBack();
    }
}
