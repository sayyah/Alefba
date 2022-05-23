using Alefba.Application.DTOs;
using Alefba.Domain.Entities;
using AutoMapper;

namespace Alefba.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exchange, Crea>().ReverseMap();
        }
    }
}
