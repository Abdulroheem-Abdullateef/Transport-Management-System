using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;

namespace TransportManagementSystem.Entities
{
    public class Trip : BaseEntity
    {
        public string TripReference { get; set; }

        public int BusId { get; set; }

        public Bus Bus { get; set; }

        public Location TakeOffPoint { get; set; }

        public Location LandingPoint { get; set; }

        public DateTime TakeOffTime { get; set; }

        public DateTime LandingTime { get; set; }

        public int DriverId { get; set; }

        public User Driver { get; set; }

        public decimal Price { get; set; }

        public TripStatus Status { get; set; }

        public int AvailableSeat { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
