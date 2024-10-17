using EventManagement_Backend.Models;

namespace EventManagement_Frontend.Models
{
    public class ReviewModel
    {
        public int ReviewId {  get; set; }
        public decimal Rating { get; set; }

        public string Comment { get; set; } = null!;

        public DateTime ReviewDate { get; set; }
        //public Event? Events { get; set; } = null!;
    }
}