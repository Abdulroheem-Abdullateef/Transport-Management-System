using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;

namespace TransportManagementSystem.Entities
{
    public class Booking : BaseEntity
    {
        public string BookingReference { get; set; }

        public int PassengerId { get; set; }

        public User Passenger { get; set; }

        public int TripId { get; set; }

        public Trip Trip { get; set; }

        public string NextOfKin { get; set; }

        public string Address { get; set; }

        public BookingStatus BookingStatus { get; set; }

        public bool IsPaid { get; set; }
    }
}
