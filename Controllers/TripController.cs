using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;
using TransportManagementSystem.Interfaces.Services;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Controllers
{
    public class TripController : Controller
    {
        private readonly ITripService _tripService;
        private readonly IUserService _userService;
        private readonly IBookingService _bookingService;
        public TripController(ITripService tripService, IUserService userService, IBookingService bookingService)
        {
            _tripService = tripService;
            _userService = userService;
            _bookingService = bookingService;
        }
        public IActionResult Index()
        {
            return View(_tripService.GetTrips());
        }

        public IActionResult SearchTrip(Location from, Location to, DateTime date)
        {
            return View(_tripService.GetScheduledTripsByLocationByDate(from, to, date));
        }
        public IActionResult ScheduleTrip(int id)
        {
            var drivers = _userService.GetDrivers();
            ViewData["Drivers"] = new SelectList(drivers, "Id", "FirstName");
            return View();
        }

        [HttpPost]
        public IActionResult ScheduleTrip(CreateTripRequestModel model)
        {
            _tripService.ScheduleTrip(model);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult BookTicket(int id)
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult BookTicket(CreateBookingRequestModel model)
        {

           var bookingReference = _bookingService.BookTicket(model);
            return RedirectToAction("SuccessPage", new { bookingReference.BookingReference });
        }


        public IActionResult SuccessPage(string bookingReference)
        {
            var booking = _bookingService.GetByReference(bookingReference);
            if (booking == null)
            {
                return NotFound();
            }
            else
            {
                return View(booking);
            }
        
        }
    }
}
