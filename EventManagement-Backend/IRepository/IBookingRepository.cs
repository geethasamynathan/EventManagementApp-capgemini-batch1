using EventManagement_Backend.Models;

namespace EventManagement_Backend.IRepository
{
   
        public interface IBookingRepository
        {
            Task<Booking> CreateBookingAsync(Booking booking);
            Task<Booking> GetBookingByIdAsync(int bookingId);
            Task<IEnumerable<Booking>> GetAllBookingsAsync();
            Task<bool> UpdateBookingAsync(Booking booking);
            Task<bool> DeleteBookingAsync(int bookingId);
        }
    
}
