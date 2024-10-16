using EventManagement_Backend.DTOs;
using EventManagement_Backend.PaymentDTOs;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement_Backend.IRepository
{
    public interface IPaymentRepository
    {
        PaymentDTO ProcessPayment(ProcessPaymentDTO processPaymentDto);
    }
}
