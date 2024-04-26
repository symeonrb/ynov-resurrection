using YnovResurrection.Models;
using YnovResurrection.Services;

namespace YnovResurrection.ViewModels.Pages
{
    class CoursesListPageViewModel
    {
        // public CoursesListPageViewModel()
        // {
        // }

        public ICollection<Course> Courses
        {
            get { return CourseService.Instance.List(); }
            // set { _CoursesList = value; }
        }
    }
}
