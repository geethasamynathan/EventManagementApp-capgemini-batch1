using EventManagement_Frontend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EventManagement_Frontend.Controllers
{
    public class TicketController : Controller
    {
        public IActionResult Create()
        {
            var availableSeats = GetAvailableSeats();
            ViewBag.AvailableSeats = availableSeats; // Pass available seats to the view
            return View(new TicketModel()); // Pass an empty model to the view
        }

        // POST: Ticket/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TicketModel model)
        {
            if (ModelState.IsValid)
            {
                // For now, let's just simulate a booking ID and total amount calculation
                model.BookingID = new System.Random().Next(1, 1000); // Simulating a booking ID
                model.TotalAmount = model.NumberOfTickets * 100; // Assuming a ticket price of $20

                // Store model data in TempData
                TempData["BookingData"] = JsonConvert.SerializeObject(model);

                // Redirect to the confirmation page
                return RedirectToAction("Confirmation");
            }

            // If we got this far, something failed; redisplay the form
            ViewBag.AvailableSeats = GetAvailableSeats(); // Replace with actual seat retrieval logic
            return View(model);
        }

        public IActionResult Confirmation()
        {
            // Retrieve model data from TempData
            var modelData = TempData["BookingData"] as string;

            if (!string.IsNullOrEmpty(modelData))
            {
                var model = JsonConvert.DeserializeObject<TicketModel>(modelData);
                return View(model); // Pass the model to the view
            }

            return RedirectToAction("Create"); // Redirect to create if no data is found
        }

        private List<int> GetAvailableSeats()
        {
            // Simulate available seats (e.g., from a database)
            var availableSeats = new List<int>();
            for (int i = 1; i <= 40; i++)
            {
                availableSeats.Add(i);
            }
            return availableSeats; // Return list of 40 seats
        }
    }
}
