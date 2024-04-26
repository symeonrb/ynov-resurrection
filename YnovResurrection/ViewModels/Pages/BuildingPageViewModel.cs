using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    public class BuildingPageViewModel
    {
        private readonly BuildingService _buildingService;
        public required ModelListPage Page { get; set; }
        public Building Model { get; private set; }
        public bool IsEditMode { get; set; } = false;
        public bool IsAddMode { get; set; } = false;

        public BuildingPageViewModel(BuildingService buildingService, Building building)
        {
            _buildingService = buildingService;
            Model = IModel.Clone(building);
        }

        public ICollection<School> Schools => SchoolService.Instance.List();

        public void AddBuilding()
        {
            if (Page.DataContext is not BuildingsListPageViewModel viewModel) return;
            _buildingService.CreateBuilding(Model.Address, Model.School);
            viewModel.Refresh();
        }

        public void SaveBuilding()
        {
            if (Page.DataContext is not BuildingsListPageViewModel viewModel) return;
            _buildingService.EditBuilding(Model);
            viewModel.Refresh();
        }
    }
}
