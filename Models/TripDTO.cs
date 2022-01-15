using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;

namespace TransportManagementSystem.Models
{
    public class TripDTO
    {
        public int Id { get; set; }

        public string TripReference { get; set; }

        public int BusId { get; set; }

        public string BusModel { get; set; }

        public BusType BusType { get; set; }

        public string RegistrationNumber { get; set; }

        public string PlateNumber { get; set; }

        public int Capacity { get; set; }

        public Location TakeOffPoint { get; set; }

        public Location LandingPoint { get; set; }

        public DateTime TakeOffTime { get; set; }

        public DateTime LandingTime { get; set; }

        public int DriverId { get; set; }

        public string DriverName { get; set; }

        public decimal Price { get; set; }

        public TripStatus Status { get; set; }

        public int AvailableSeat { get; set; }

        public List<BookingDTO> Bookings { get; set; } = new List<BookingDTO>();
    }

    public class CreateTripRequestModel
    {
        public int BusId { get; set; }
        public Location TakeOffPoint { get; set; }

        public Location LandingPoint { get; set; }

        public DateTime TakeOffTime { get; set; }

        public DateTime LandingTime { get; set; }

        public int DriverId { get; set; }

        public decimal Price { get; set; }
    }

    public class SearchTripRequestModel
    {
        
        public Location TakeOffPoint { get; set; }

        public Location LandingPoint { get; set; }

        public DateTime TakeOffTime { get; set; }

       
    }
}
