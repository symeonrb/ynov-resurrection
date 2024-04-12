using YnovResurrection.Models;

namespace YnovResurrection.ViewModels.Pages
{
    class CoursesListPageViewModel
    {
        private IList<Course> _CoursesList;

        public CoursesListPageViewModel() 
        { 
            _CoursesList =
            [
                // Ajouter quelques bâtiments de test
            ];
        }

        public IList<Course> Courses
        {
            get {  return _CoursesList; }
            set { _CoursesList = value; }
        }
    }
}
