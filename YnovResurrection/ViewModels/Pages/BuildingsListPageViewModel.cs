using System.Windows.Controls;
using System.Windows.Navigation;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    class BuildingsListPageViewModel : IDataListPageViewModel
    {

        // public BuildingsListPageViewModel()
        // {
        // }

        public Type ModelType => typeof(Building);

        public Page? EditModel(DataListPage page, IModel? modelNullable)
        {
            var buildingNullable = modelNullable ?? new Building();
            if (buildingNullable is not Building building) return null;
            BuildingPageViewModel editViewModel = new(building)
            {
                Page = page,
                IsEditMode = modelNullable != null,
                IsAddMode = modelNullable == null
            };
            BuildingPage editPage = new(editViewModel);
            return editPage;
        }

        public void DeleteModel(IModel model)
        {
            if (model is not Building building) return;
            BuildingService.Instance.DeleteBuilding(building);
        }

        public ICollection<Building> List => BuildingService.Instance.List();
    }
}
