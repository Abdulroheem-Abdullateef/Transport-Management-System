using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Interfaces.Services;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Controllers
{
    public class BusController : Controller
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }
        public IActionResult Index()
        {
            return View(_busService.GetBuses());
        }

        public IActionResult RegisterBus()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterBus(CreateBusRequestModel busModel)
        {
            _busService.RegisterBus(busModel);
            return RedirectToAction("Index");
        }

    }
}
