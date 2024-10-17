using AutoMapper;
using EventManagement_Backend.DTO;
using EventManagement_Backend.Models;

namespace EventManagement_Backend.MappingProfile
{
    public class BookingProfile : Profile
    {

        public BookingProfile()
        {
            CreateMap<Booking, BookingDTO>().ReverseMap();
        }
    }
}
