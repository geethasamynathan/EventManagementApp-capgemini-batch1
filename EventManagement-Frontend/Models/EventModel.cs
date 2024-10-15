using System.ComponentModel.DataAnnotations;

namespace EventManagement_Frontend.Models
{
    public class EventModel
    {
        [Required(ErrorMessage = "Event Name is required")]
        [StringLength(100)]
        public string EventName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(200)]
        public string Location { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [StringLength(50)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Image URL is required")]
        [StringLength(255)]
        public string ImageURL { get; set; }

        public double Rating { get; set; }

        [Required(ErrorMessage = "Total Tickets is required")]
        public int TotalTickets { get; set; }

        public int AvailableTickets { get; set; }
    }
}
