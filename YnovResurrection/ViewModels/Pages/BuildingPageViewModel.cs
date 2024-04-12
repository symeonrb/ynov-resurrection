using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    public class BuildingPageViewModel
    {
        public required ModelListPage Page { get; set; }
        public Building Model { get; private set; }
        public bool IsEditMode { get; set; } = false;
        public bool IsAddMode { get; set; } = false;

        public BuildingPageViewModel(Building building)
        {
            Model = IModel.Clone(building);
        }

        public ICollection<School> Schools => SchoolService.Instance.List();
    }
}
