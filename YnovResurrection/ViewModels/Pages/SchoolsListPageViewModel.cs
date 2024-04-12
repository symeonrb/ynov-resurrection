using YnovResurrection.Models;
using YnovResurrection.Services;

namespace YnovResurrection.ViewModels.Pages
{
    class SchoolsListPageViewModel
    {
        // public SchoolsListPageViewModel()
        // {
        // }

        public ICollection<School> List
        {
            get { return SchoolService.Instance.List(); }
            // set { _CoursesList = value; }
        }
    }
}
