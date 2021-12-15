using BuildNRent.Dtos;
using BuildNRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;

namespace BuildNRent.Profiles
{
    public class InteractionProfile : Profile
    {
        public InteractionProfile()
        {
            CreateMap<Interaction, InteractionReadDto>();
            CreateMap<InteractionCreateDto, Interaction>();
            CreateMap<InteractionUpdateDto, Interaction>();
            CreateMap<Interaction, InteractionUpdateDto>();
        }
    }
}
