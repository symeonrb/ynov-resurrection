using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using System.ComponentModel;
using YnovResurrection.Models;

namespace YnovResurrection.Services
{
    public class BuildingService(AppDb appDb)
    {
        private readonly AppDb _appDb = appDb ?? throw new ArgumentNullException(nameof(appDb));

        public Building CreateBuilding(string address, School school)
        {
            var building = new Building
            {
                Id = Guid.NewGuid().ToString(),
                Address = address,
                School = school,
                Rooms = []
            };

            _appDb.Buildings.Add(building);
            _appDb.SaveChanges();

            return building;
        }

        public void RemoveBuilding(Building building)
        {
            _appDb.Buildings.Remove(building);
            _appDb.SaveChanges();
        }

        public void EditBuilding(Building building)
        {
            _appDb.Buildings.Update(building);
            _appDb.SaveChanges();
        }

        public ObservableCollection<Building> List()
        {
            _appDb.Buildings.Load(); // Charger les données de la base de données dans la collection locale

            return new ObservableCollection<Building>(_appDb.Buildings.Local);
        }
    }
}