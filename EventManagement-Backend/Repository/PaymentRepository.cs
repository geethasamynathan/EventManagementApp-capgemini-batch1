using AutoMapper;
using EventManagement_Backend.DTOs;
using EventManagement_Backend.IRepository;
using EventManagement_Backend.Models;
using EventManagement_Backend.PaymentDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace EventManagement_Backend.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IMapper _mapper;
        private readonly EventManagementDbContext _context;

        public PaymentRepository(EventManagementDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public PaymentDTO ProcessPayment(ProcessPaymentDTO processPaymentDto)
        {
            // Validate card details (basic validation)
            if (!IsValidCard(processPaymentDto.CardNumber, processPaymentDto.ExpirationDate, processPaymentDto.CVV))
            {
                //throw new PaymentProcessingException("Invalid card details.");
                return null;
            }

            var payment = new Payment
            {
                UserId = processPaymentDto.UserId,
                TotalAmount = processPaymentDto.TotalAmount,
                EventId = processPaymentDto.EventId,
                PaymentDate = DateTime.Now,
                Cvv = int.Parse(processPaymentDto.CVV),
                CardNumber = long.Parse(processPaymentDto.CardNumber),
                ExpiryDate = DateOnly.Parse(processPaymentDto.ExpirationDate),
                PaymentStatus = "confirmed" // In a real scenario, you might check payment gateway status
            };
            _context.Payments.Add(payment);
            _context.SaveChanges();
            var paymentDto = _mapper.Map<PaymentDTO>(payment);
            return paymentDto;
        }
        public bool IsValidCard(string cardNumber, string expirationDate, string cvv)
        {
            bool isValidCardNumber = cardNumber.Length == 16;
            bool isValidExpirationDate = DateTime.TryParseExact(expirationDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var expiryDate) && expiryDate > DateTime.Now;
            bool isValidCvv = cvv.Length == 3;

            return isValidCardNumber && isValidExpirationDate && isValidCvv;
        }
    }
}
