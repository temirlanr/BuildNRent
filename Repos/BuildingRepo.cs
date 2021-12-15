using BuildNRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildNRent.Repos
{
    public interface IBuildingRepo
    {
        bool SaveChanges();

        Building GetBuildingById(int id);
        IEnumerable<Building> GetAllBuildings();
        void CreateBuilding(Building building);
        void UpdateBuilding(Building building);
        void DeleteBuilding(Building building);
    }
    public class BuildingRepo : IBuildingRepo
    {

        private readonly BnRContext _context;

        public BuildingRepo(BnRContext context)
        {
            _context = context;
        }
        public void CreateBuilding(Building building)
        {
            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            _context.Buildings.Add(building);
        }

        public void DeleteBuilding(Building building)
        {
            if (building == null)
            {
                throw new ArgumentNullException(nameof(building));
            }

            _context.Buildings.Remove(building);
        }

        public IEnumerable<Building> GetAllBuildings()
        {
            return _context.Buildings.ToList();
        }

        public Building GetBuildingById(int id)
        {
            return _context.Buildings.FirstOrDefault(i => i.BuildingId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateBuilding(Building building) {  }
    }
}
