using YnovResurrection.Models;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    public class BuildingPageViewModel
    {
        public required BuildingsListPage Page { get; set; }
        public Building BuildingCopy { get; private set; }
        public Building Building { get; set; }
        public bool IsEditMode { get; set; } = false;
        public bool IsAddMode { get; set; } = false;

        public BuildingPageViewModel(Building building)
        {
            Building = building;
            BuildingCopy = IModel.Clone(Building);
        }
    }
}
