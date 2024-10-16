using EventManagement_Backend.IRepository;
using EventManagement_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatController : ControllerBase
    {
        private readonly ISeatRepository _seatRepository;
        public SeatController(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }
        [HttpPost]
        public IActionResult BookSeat(int seatId , List<int> seatIds)
        {
            bool seatBooked = _seatRepository.UpdateSeat(seatId ,seatIds);
            if (seatBooked)
            {
                return Ok();
            }
            else
            {
                return BadRequest("No seat booked");
            }
        }
    }
}
