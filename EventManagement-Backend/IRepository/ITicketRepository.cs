using EventManagement_Backend.Models;

namespace EventManagement_Backend.IRepository
{
    public interface ITicketRepository
    {
        // Method to book a ticket
        Ticket BookTicket(Ticket ticket);

        // Method to cancel a ticket
        bool CancelTicket(int ticketId);

        // Method to view all booked tickets
        IEnumerable<Ticket> GetBookedTickets(int TicketId);

        // Method to get a specific ticket by ticket ID
    }
}
