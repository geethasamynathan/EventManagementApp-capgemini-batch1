﻿//using EventManagement_Backend.IRepository;
//using EventManagement_Backend.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;

//namespace EventManagement_Backend.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class EventsController : ControllerBase
//    {
//        private readonly IEventRepository _eventRepository;
//        public EventsController(IEventRepository eventRepository)
//        {
//            _eventRepository = eventRepository;
//        }

//        // GET: api/event
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Event>>> GetAllEvents()
//        {
//            var events = _eventRepository.GetAllEvents();
//            return Ok(events);
//        }

//        // GET: api/event/{id}
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Event>> GetEventById(int id)
//        {
//            var eventEntity = _eventRepository.GetEventById(id)
//;

//            if (eventEntity == null)
//            {
//                return NotFound(); // Return 404 if event not found
//            }

//            return Ok(eventEntity);
//        }

//        // POST: api/event
//        [HttpPost]
//        public async Task<ActionResult<Event>> CreateEvent(Event eventEntity)
//        {

//            var item = _eventRepository.CreateEvent(eventEntity);
//            if (item == null)
//            {
//                return Ok(item);
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }
//        // PUT: api/event/{id}
//        [HttpPut("{id}")]
//        public async Task<ActionResult<Event>> UpdateEvent(int id, Event eventEntity)
//        {
//            var existingEvent = _eventRepository.GetEventById(id)
//;
//            if (existingEvent != null)
//            {
//                var updatedEvent = _eventRepository.UpdateEvent(eventEntity);
//                return Ok(updatedEvent);
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }

//        // DELETE: api/event/{id}
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteEvent(int id)
//        {
//            var existingEvent = _eventRepository.GetEventById(id)
//;
//            if (existingEvent != null)
//            {
//                _eventRepository.DeleteEvent(id)
//;
//                return NoContent();
//            }
//            else
//            {
//                return NotFound();
//            }
//        }
//        [HttpGet("{name}")]
//        public async Task<IActionResult> GetByName(string name)
//        {
//            var item = _eventRepository.GetByName(name);
//            if (item != null)
//            {
//                return Ok(item);
//            }
//            else
//            {
//                return BadRequest();
//            }
//        }
//    }
//}
