using EventManagement_Backend.IRepository;
using EventManagement_Backend.PaymentDTOs;
using EventManagement_Backend.Models;
using EventManagement_Backend.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Reflection.Metadata.BlobBuilder;

namespace EventManagement_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly ILogger<PaymentsController> _logger;

        public PaymentsController(IPaymentRepository paymentRepository, ILogger<PaymentsController> logger)
        {
            _paymentRepository = paymentRepository;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentDTO processPaymentDto)
        {
            try
            {
                var result = _paymentRepository.ProcessPayment(processPaymentDto);

                if (result == null)
                {
                    return BadRequest("Payment processing failed.");
                }
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Error processing payment");
                return BadRequest(new { Message = e.Message, Exception = e.InnerException?.Message });
            }
        }
    }
}
