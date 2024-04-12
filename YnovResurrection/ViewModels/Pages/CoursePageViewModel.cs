using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    public class CoursePageViewModel
    {
        public required ModelListPage Page { get; set; }
        public Course ModelCopy { get; private set; }
        public Course Model { get; set; }
        public bool IsEditMode { get; set; } = false;
        public bool IsAddMode { get; set; } = false;

        public CoursePageViewModel(Course course)
        {
            Model = course;
            ModelCopy = IModel.Clone(Model);
        }

        public ICollection<Module> Modules => ModuleService.Instance.List();
    }
}
