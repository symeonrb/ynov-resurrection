using YnovResurrection.Models;
using YnovResurrection.Services;

namespace YnovResurrection.ViewModels.Pages
{
    class BuildingsListPageViewModel
    {

        // public BuildingsListPageViewModel()
        // {
        // }

        public ICollection<Building> Buildings
        {
            get {  return BuildingService.Instance.List(); }
            // set { _BuildingsList = value; }
        }
    }
}
