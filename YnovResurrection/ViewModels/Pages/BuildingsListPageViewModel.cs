using YnovResurrection.Models;

namespace YnovResurrection.ViewModels.Pages
{
    class BuildingsListPageViewModel
    {
        private IList<Building> _BuildingsList;

        public BuildingsListPageViewModel() 
        { 
            _BuildingsList =
            [
                // Ajouter quelques bâtiments de test
                new() { Id = Guid.NewGuid().ToString(), Address = "123 Main St", School = new() { Name = "Ynov A" } },
                new() { Id = Guid.NewGuid().ToString(), Address = "456 Elm St", School = new() { Name = "Ynov B" } },
                new() { Id = Guid.NewGuid().ToString(), Address = "789 Oak St", School = new() { Name = "Ynov C" } },
            ];
        }

        public IList<Building> Buildings
        {
            get {  return _BuildingsList; }
            set { _BuildingsList = value; }
        }
    }
}
