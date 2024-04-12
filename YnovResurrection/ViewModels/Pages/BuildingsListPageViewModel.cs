using YnovResurrection.Models;
using YnovResurrection.Services;

namespace YnovResurrection.ViewModels.Pages
{
    class BuildingsListPageViewModel
    {

        // public BuildingsListPageViewModel()
        // {
        // }

        public ICollection<Building> List
        {
            get {  return BuildingService.Instance.List(); }
            // set { _BuildingsList = value; }
        }
    }
}
