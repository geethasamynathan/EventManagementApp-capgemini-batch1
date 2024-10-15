using EventManagement_Backend.Authentication;
using EventManagement_Backend.IRepository;
using EventManagement_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace EventManagement_Backend.Repository
{
    public class BookingRepositroy : IBookingRepository
    {
        private readonly EventManagementDbContext _context;

        public BookingRepositroy(EventManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            return await _context.Bookings.FindAsync(bookingId);
        }

        public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<bool> UpdateBookingAsync(Booking booking)
        {
            _context.Entry(booking).State = EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteBookingAsync(int bookingId)
        {
            var booking = await GetBookingByIdAsync(bookingId);
            if (booking == null) return false;

            _context.Bookings.Remove(booking);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
