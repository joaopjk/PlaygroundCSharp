using AirlineWeb.Dtos;
using AirlineWeb.Models;
using AutoMapper;

namespace AirlineWeb.Profiles
{
    public class FlightDetailProfile : Profile
    {
        public FlightDetailProfile()
        {
            CreateMap<FlightDetail, FlightDetailReadDto>();
            CreateMap<FlightDetail, FlightDetailCreateDto>();
            CreateMap<FlightDetailUpdateDto, FlightDetail>();
        }
    }
}
