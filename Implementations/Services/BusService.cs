using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Interfaces.Repositories;
using TransportManagementSystem.Interfaces.Services;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Implementations.Services
{
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }
        public IList<BusDTO> GetAvailableBuses()
        {
            return _busRepository.GetAvailableBuses().Select(bus => new BusDTO
            {
                Id = bus.Id,
                BusType = bus.BusType,
                Capacity = bus.Capacity,
                Model = bus.Model,
                PlateNumber = bus.PlateNumber,
                RegistrationNumber = bus.RegistrationNumber,
                TripStatus = bus.TripStatus,
                AvailabilityStatus = bus.AvailabilityStatus,
                Trips = bus.Trips.Select(trip => new TripDTO
                {
                    Id = trip.Id,
                    BusId = trip.BusId,
                    TripReference = trip.TripReference,

                }).ToList()
            }).ToList();
        }

        public BusDTO GetBus(int id)
        {
            var bus = _busRepository.Get(id);
            return new BusDTO
            {
                Id = bus.Id,
                BusType = bus.BusType,
                Capacity = bus.Capacity,
                Model = bus.Model,
                PlateNumber = bus.PlateNumber,
                RegistrationNumber = bus.RegistrationNumber,
                TripStatus = bus.TripStatus,
                AvailabilityStatus = bus.AvailabilityStatus,
                Trips = bus.Trips.Select(trip => new TripDTO
                {
                    Id = trip.Id,
                    BusId = trip.BusId,
                    TripReference = trip.TripReference,

                }).ToList()
            };
        }

        public IList<BusDTO> GetBuses()
        {
            return _busRepository.GetAll().Select(bus => new BusDTO
            {
                Id = bus.Id,
                BusType = bus.BusType,
                Capacity = bus.Capacity,
                Model = bus.Model,
                PlateNumber = bus.PlateNumber,
                RegistrationNumber = bus.RegistrationNumber,
                TripStatus = bus.TripStatus,
                AvailabilityStatus = bus.AvailabilityStatus,
                Trips = bus.Trips.Select(trip => new TripDTO
                {
                    Id = trip.Id,
                    BusId = trip.BusId,
                    TripReference = trip.TripReference,
                    
                }).ToList()
            }).ToList();
        }

        public bool RegisterBus(CreateBusRequestModel model)
        {
            var bus = new Bus
            {
                BusType = model.BusType,
                AvailabilityStatus = true,
                Capacity = model.Capacity,
                Created = DateTime.Now,
                IsDeleted = false,
                Modified = DateTime.Now,
                PlateNumber = model.PlateNumber,
                Model = model.Model,
                RegistrationNumber = model.RegistrationNumber,
                TripStatus = true
            };
            _busRepository.Create(bus);
            return true;
        }
    }
}
