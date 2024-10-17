using AutoMapper;
using EventManagement_Backend.Models;
using EventManagement_Backend.PaymentDTOs;

namespace EventManagement_Backend.MappingProfile
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentDTO>().ReverseMap();
        }
    }
}
