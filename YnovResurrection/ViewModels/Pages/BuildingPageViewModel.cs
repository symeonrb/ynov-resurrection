using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    public class BuildingPageViewModel
    {
        public required DataListPage Page { get; set; }
        public Building ModelCopy { get; private set; }
        public Building Model { get; set; }
        public bool IsEditMode { get; set; } = false;
        public bool IsAddMode { get; set; } = false;

        public BuildingPageViewModel(Building building)
        {
            Model = building;
            ModelCopy = IModel.Clone(Model);
        }

        public ICollection<School> Schools => SchoolService.Instance.List();
    }
}
