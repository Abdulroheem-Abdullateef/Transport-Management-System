using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;
using TransportManagementSystem.Interfaces.Services;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITripService _tripService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ITripService tripService, ILogger<HomeController> logger)
        {
            _tripService = tripService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SearchTrip(SearchTripRequestModel model)
        {
            var trips = _tripService.GetScheduledTripsByLocationByDate(model.TakeOffPoint, model.LandingPoint, model.TakeOffTime);
            return View("SearchTrip", trips);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
