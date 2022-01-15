using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;

namespace TransportManagementSystem.Entities
{
    public class Bus : BaseEntity
    {
        public string Model { get; set; }

        public BusType BusType { get; set; }

        public string RegistrationNumber { get; set; }

        public string PlateNumber { get; set; }

        public int Capacity { get; set; }

        public bool AvailabilityStatus { get; set; }

        public bool TripStatus { get; set; }

        public ICollection<Trip> Trips { get; set; } = new List<Trip>();
    }
}
