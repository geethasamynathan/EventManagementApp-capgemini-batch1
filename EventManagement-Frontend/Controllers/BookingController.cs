using EventManagement_Frontend.IService;
using EventManagement_Frontend.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement_Frontend.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        // GET: Booking/Index
        public async Task<IActionResult> Index()
        {
            var bookings = await _bookingService.GetAllBookings();
            return View(bookings);
        }

        // GET: Booking/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var booking = await _bookingService.GetBookingDetails(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }
    }
}
