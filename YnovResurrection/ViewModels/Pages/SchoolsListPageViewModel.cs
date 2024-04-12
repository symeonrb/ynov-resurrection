using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    class SchoolsListPageViewModel : IDataListPageViewModel
    {
        public Type ModelType => typeof(School);

        public Page? EditModel(DataListPage page, IModel? modelNullable)
        {
            var schoolNullable = modelNullable ?? new School();
            if (schoolNullable is not School school) return null;
            SchoolPageViewModel editViewModel = new(school)
            {
                Page = page,
                IsEditMode = modelNullable != null,
                IsAddMode = modelNullable == null
            };
            SchoolPage editPage = new(editViewModel);
            return editPage;
        }

        public void DeleteModel(IModel model)
        {
            if (model is not School school) return;
            SchoolService.Instance.DeleteSchool(school);
        }

        public ICollection<School> List => SchoolService.Instance.List();
    }
}
