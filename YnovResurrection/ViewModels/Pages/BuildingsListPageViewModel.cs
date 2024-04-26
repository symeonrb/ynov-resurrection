using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using YnovResurrection.Models;
using YnovResurrection.Services;
using YnovResurrection.Views.Pages;

namespace YnovResurrection.ViewModels.Pages
{
    class BuildingsListPageViewModel : INotifyPropertyChanged, IModelListPageViewModel
    {
        private readonly BuildingService _buildingService;
        public Type ModelType => typeof(Building);
        public string Title => "Gestion des Bâtiments";

        public event PropertyChangedEventHandler? PropertyChanged;

        private ObservableCollection<Building> _buildings;

        public ObservableCollection<Building> Buildings
        {
            get { return _buildings; }
            private set { _buildings = value; RaisePropertyChanged(nameof(Buildings)); }
        }

        public BuildingsListPageViewModel(BuildingService buildingService)
        {
            _buildingService = buildingService;
            Buildings = _buildingService.List();
        }

        public Page? EditModel(ModelListPage page, IModel? modelNullable)
        {
            var buildingNullable = modelNullable ?? new Building();
            if (buildingNullable is not Building building) return null;
            BuildingPageViewModel editViewModel = new(_buildingService, building)
            {
                Page = page,
                IsEditMode = modelNullable != null,
                IsAddMode = modelNullable == null
            };
            BuildingPage editPage = new(editViewModel);
            return editPage;
        }

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void DeleteModel(IModel model)
        {
            if (model is not Building building) return;
            DeleteBuilding(building);
        }

        public void DeleteBuilding(Building building)
        {
            try
            {
                _buildingService.RemoveBuilding(building);
                Refresh();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur lors de la migration de la base de données : " + ex.Message);
            }
        }

        public void Refresh()
        {
            Buildings = _buildingService.List();
        }
    }
}
