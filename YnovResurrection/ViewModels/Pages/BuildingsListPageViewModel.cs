using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using YnovResurrection.Models;
using YnovResurrection.Services;

namespace YnovResurrection.ViewModels.Pages
{
    class BuildingsListPageViewModel : INotifyPropertyChanged
    {
        private readonly BuildingService _buildingService;

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

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
