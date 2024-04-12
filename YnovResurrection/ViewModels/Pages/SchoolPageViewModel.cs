using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    public class SchoolPageViewModel
    {
        public required ModelListPage Page { get; set; }
        public School Model { get; private set; }
        public bool IsEditMode { get; set; } = false;
        public bool IsAddMode { get; set; } = false;

        public SchoolPageViewModel(School school)
        {
            Model = IModel.Clone(school);
        }
    }
}
