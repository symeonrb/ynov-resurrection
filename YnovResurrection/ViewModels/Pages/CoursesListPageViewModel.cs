using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    class CoursesListPageViewModel : IModelListPageViewModel
    {
        public Type ModelType => typeof(Course);
        public string Title => "Gestion des Cours";

        public Page? EditModel(ModelListPage page, IModel? modelNullable)
        {
            var courseNullable = modelNullable ?? new Course();
            if (courseNullable is not Course course) return null;
            CoursePageViewModel editViewModel = new(course)
            {
                Page = page,
                IsEditMode = modelNullable != null,
                IsAddMode = modelNullable == null
            };
            CoursePage editPage = new(editViewModel);
            return editPage;
        }

        public void DeleteModel(IModel model)
        {
            if (model is not Course course) return;
            CourseService.Instance.DeleteCourse(course);
        }

        public ICollection<Course> List => CourseService.Instance.List();
    }
}
