using EventManagement_Backend.IRepository;
using EventManagement_Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingsController(IBookingRepository bookingService)
        {
            _bookingRepository = bookingService;
        }

        // GET: api/bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();
            return Ok(bookings);
        }

        // GET: api/bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBooking(int id)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            return Ok(booking);
        }

        // POST: api/bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBooking(Booking booking)
        {
            if (booking == null)
            {
                return BadRequest();
            }

            var createdBooking = await _bookingRepository.CreateBookingAsync(booking);
            return CreatedAtAction(nameof(GetBooking), new { id = createdBooking.BookingId }, createdBooking);
        }

        // PUT: api/bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.BookingId)
            {
                return BadRequest();
            }

            var result = await _bookingRepository.UpdateBookingAsync(booking);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var result = await _bookingRepository.DeleteBookingAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
