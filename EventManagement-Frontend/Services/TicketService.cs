using EventManagement_Backend.Models;
using EventManagement_Frontend.IService;
using EventManagement_Frontend.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Security.Policy;
using System.Text;

namespace EventManagement_Frontend.Services
{
    public class TicketService : ITicketService
    {
        private readonly List<CategoryModel> _categories = new List<CategoryModel>();
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private string _url = "";
        private EventManagementDbContext _context;

        public TicketService(HttpClient httpClient, IConfiguration config,EventManagementDbContext context)
        {
            _httpClient = httpClient;
            _config = config;
            _context = context;
            _url = _config["ApiSettings:BaseUrl"] + "/Ticket";
            if (string.IsNullOrEmpty(_url))
            {
                throw new ArgumentNullException(nameof(_url), "The base URL for the API cannot be null or empty.");
            }
            _httpClient.BaseAddress = new Uri(_url);

        }
        //public async Task<TicketModel> AddTicket(TicketModel ticket)
        //{
        //    //TicketModel ticketItem = new TicketModel()
        //    //{
        //    //    SeatId =ticket.SeatId,
        //    //    NumberOfTickets=ticket.NumberOfTickets,
        //    //    BookingID=ticket.BookingID, 
        //    //    TotalAmount=ticket.TotalAmount

        //    //};
        //    var jsonContent = new StringContent(JsonConvert.SerializeObject(ticketItem), Encoding.UTF8, "application/json");
        //    string url = _url;
        //    var response = await _httpClient.PostAsync(url, jsonContent);
        //    if (response.IsSuccessStatusCode)
        //    {

        //        return ticketItem;
        //    }
        //    return null;
        //}
    }
}
