using Application.Models;
using AutoMapper;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ProfilesMapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NewProperityRequest, Property>();
            CreateMap<Property, ProperityDto>().ReverseMap();
        }

    }
}
