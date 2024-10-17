using System.ComponentModel.DataAnnotations;

namespace EventManagement_Frontend.Models
{
    public class TicketModel
    {
        [Required(ErrorMessage = "Booking ID is required")]
        public int BookingID { get; set; }

        //[Required(ErrorMessage = "Seat number is required")]
        public int SeatNumber { get; set; }

        [Required(ErrorMessage = "Number of ticket is required")]
        public int NumberOfTickets { get; set; }

        [Required(ErrorMessage = "Total Amount is required")]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

    }
}
