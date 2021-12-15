using BuildNRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BuildNRent.Dtos;

namespace BuildNRent.Profiles
{
    public class RenterProfile : Profile
    {
        public RenterProfile()
        {
            CreateMap<Renter, RenterReadDto>();
            CreateMap<RenterCreateDto, Renter>();
            CreateMap<RenterUpdateDto, Renter>();
            CreateMap<Renter, RenterUpdateDto>();
        }
    }
}
