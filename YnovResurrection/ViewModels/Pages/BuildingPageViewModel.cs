using System.Collections.ObjectModel;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    public class BuildingPageViewModel
    {
        private readonly BuildingService _buildingService;
        public required BuildingsListPage Page { get; set; }
        public Building BuildingCopy { get; private set; }
        public Building Building { get; set; }
        public bool IsEditMode { get; set; } = false;
        public bool IsAddMode { get; set; } = false;

        public BuildingPageViewModel(BuildingService buildingService, Building building)
        {
            _buildingService = buildingService;

            Building = building;
            BuildingCopy = IModel.Clone(Building);
        }

        public void AddBuilding()
        {
            if (Page.DataContext is BuildingsListPageViewModel viewModel)
            {
                _buildingService.CreateBuilding(BuildingCopy.Address, BuildingCopy.School);
                viewModel.Refresh();
            }
        }

        public void SaveBuilding()
        {
            if (Page.DataContext is BuildingsListPageViewModel viewModel)
            {
                Building.Address = BuildingCopy.Address;
                Building.School = BuildingCopy.School;
                _buildingService.EditBuilding(Building);
                viewModel.Refresh();
            }
        }
    }
}
