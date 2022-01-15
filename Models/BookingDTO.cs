using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;

namespace TransportManagementSystem.Models
{
    public class BookingDTO
    {
        public int Id { get; set; }

        public string BookingReference { get; set; }

        public int PassengerId { get; set; }

        public string PassengerName { get; set; }

        public int TripId { get; set; }

        public string TripReference { get; set; }

        public string NextOfKin { get; set; }

        public string Address { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public bool IsPaid { get; set; }

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
    }

    public class CreateBookingRequestModel
    {
        public int PassengerId { get; set; }

        public int TripId { get; set; }

        public string NextOfKin { get; set; }

        public string Address { get; set; }
    }
}
