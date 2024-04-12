using YnovResurrection.Models;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    public class SchoolPageViewModel
    {
        public required SchoolsPage Page { get; set; }
        public School ModelCopy { get; private set; }
        public School Model { get; set; }
        public bool IsEditMode { get; set; } = false;
        public bool IsAddMode { get; set; } = false;

        public SchoolPageViewModel(School model)
        {
            Model = model;
            ModelCopy = IModel.Clone(Model);
        }
    }
}