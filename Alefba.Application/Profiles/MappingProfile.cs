using Alefba.Application.DTOs;
using Alefba.Domain;
using AutoMapper;

namespace Alefba.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exchange, ExchangeDto>().ReverseMap();
        }
    }
}
