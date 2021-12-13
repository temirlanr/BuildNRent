using BuildNRent.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildNRent.Service
{

    public interface IRenterInterface
    {

    }
    public interface IBuildingInterface
    {

    }

    public class RenterService : IRenterInterface
    {

        private readonly IRenterRepo _renterRepo;

        public RenterService(IRenterRepo renterRepo)
        {
            _renterRepo = renterRepo;
        }


    }

    public class BuildingService : IBuildingInterface
    {

        private readonly IBuildingRepo _buildingRepo;

        public BuildingService(IBuildingRepo buildingRepo)
        {
            _buildingRepo = buildingRepo;
        }


    }
}
