using BuildNRent.Dtos;
using BuildNRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace BuildNRent.Profiles
{
    public class BuildingProfile : Profile
    {
        public BuildingProfile()
        {
            CreateMap<Building, BuildingReadDto>();
            CreateMap<BuildingCreateDto, Building>();
            CreateMap<BuildingUpdateDto, Building>();
            CreateMap<Building, BuildingUpdateDto>();
        }
    }
}
