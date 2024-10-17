﻿using EventManagement_Frontend.Models;

namespace EventManagement_Frontend.IService
{
    public interface IBookingService
    {
            Task<List<BookingModel>> GetAllBookings(); // Retrieve all bookings
          
            Task<BookingModel> GetBookingDetails(int bookingId); // Get details of a specific booking
    }
}
