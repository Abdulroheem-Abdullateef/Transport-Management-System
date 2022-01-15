using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;

namespace TransportManagementSystem.Models
{
    public class BusDTO
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public BusType BusType { get; set; }

        public string RegistrationNumber { get; set; }

        public string PlateNumber { get; set; }

        public int Capacity { get; set; }

        public bool AvailabilityStatus { get; set; }

        public bool TripStatus { get; set; }

        public List<TripDTO> Trips { get; set; } = new List<TripDTO>();
    }

    public class CreateBusRequestModel
    {
        public string Model { get; set; }

        public BusType BusType { get; set; }

        public string RegistrationNumber { get; set; }

        public string PlateNumber { get; set; }

        public int Capacity { get; set; }
    }
}
