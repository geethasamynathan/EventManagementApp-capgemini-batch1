using EventManagement_Backend.Authentication;
using EventManagement_Backend.IRepository;
using EventManagement_Backend.Models;

namespace EventManagement_Backend.Repository
{
    public class TicketRepository : ITicketRepository
    {
        private readonly EventManagementDbContext _context;

        public TicketRepository(EventManagementDbContext context)
        {
            _context = context;
        }
        public Ticket BookTicket(Ticket ticket)
        {

            _context.Tickets.Add(ticket);
            _context.SaveChanges(); 
            return ticket;
        }
        public bool CancelTicket(int ticketId)
        {
            var ticket = _context.Tickets.Find(ticketId);
            if (ticket == null)
            {
                return false;
            }
            _context.Tickets.Remove(ticket);
            _context.SaveChanges(); 
            return true;
        }
        public IEnumerable<Ticket> GetBookedTickets(int TicketId)
        {
            return _context.Tickets.Where(t => t.BookingId == TicketId).ToList(); 
        }
    }
}
