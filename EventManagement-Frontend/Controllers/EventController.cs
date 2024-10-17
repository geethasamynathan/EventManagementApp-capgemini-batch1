using EventManagement_Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace EventManagement_Frontend.Controllers
{
    public class EventController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        public EventController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _config = configuration;
        }
        // GET: Events
        public async Task<IActionResult> Index()
        {
            try
            {
                var apiUrl = _config["ApiSettings:BaseUrl"] + "/events";
                var response = await _httpClient.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var events = JsonSerializer.Deserialize<List<EventModel>>(content);
                    return View(events);
                }

                // Return an empty list in case of failure, to avoid NullReferenceException
                return View(new List<EventModel>());
            }
            catch (Exception ex)
            {
                return View(new List<EventModel>());
            }
        }

        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUrl = _config["ApiSettings:BaseUrl"] + $"/events/{id}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var eventDetails = System.Text.Json.JsonSerializer.Deserialize<EventModel>(content);

                if (eventDetails == null)
                {
                    return NotFound();
                }

                return View(eventDetails);
            }

            return NotFound(); // Handle error accordingly
        }

        // GET: Events/Create
        public IActionResult CreateEvent()
        {
            return View();
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventID,EventName,Description,Date,Location,Price")] EventModel @event)
        {
            if (ModelState.IsValid)
            {
                var apiUrl = _config["ApiSettings:BaseUrl"] + "/events";
                var jsonData = JsonSerializer.Serialize(@event);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(@event); // Handle error accordingly
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUrl = _config["ApiSettings:BaseUrl"] + $"/events/{id}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var eventDetails = JsonSerializer.Deserialize<EventModel>(content);

                if (eventDetails == null)
                {
                    return NotFound();
                }

                return View(eventDetails);
            }

            return NotFound(); // Handle error accordingly
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventID,EventName,Description,Date,Location,Price")] EventModel @event)
        {
            if (id != @event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var apiUrl = _config["ApiSettings:BaseUrl"] + $"/events/{id}";
                var jsonData = JsonSerializer.Serialize(@event);
                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(@event); // Handle error accordingly
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var apiUrl = _config["ApiSettings:BaseUrl"] + $"/events/{id}";
            var response = await _httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var eventDetails = JsonSerializer.Deserialize<EventModel>(content);

                if (eventDetails == null)
                {
                    return NotFound();
                }

                return View(eventDetails);
            }

            return NotFound(); // Handle error accordingly
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var apiUrl = _config["ApiSettings:BaseUrl"] + $"/events/{id}";
            var response = await _httpClient.DeleteAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }

            return NotFound(); // Handle error accordingly
        }
    }
}
