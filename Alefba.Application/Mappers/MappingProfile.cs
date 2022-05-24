using Alefba.Application.Commands;
using Alefba.Application.DTOs;
using Alefba.Domain.Entities;
using AutoMapper;

namespace Alefba.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exchange, ExchangeDto>().ReverseMap();
            CreateMap<Exchange, CreateExchangeCommand>().ReverseMap();
        }
    }
}
