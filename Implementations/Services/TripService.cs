using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Enums;
using TransportManagementSystem.Interfaces.Repositories;
using TransportManagementSystem.Interfaces.Services;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Implementations.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        private readonly IBusRepository _busRepository;
        public TripService(ITripRepository tripRepository, IBusRepository busRepository)
        {
            _tripRepository = tripRepository;
            _busRepository = busRepository;
        }
        public IList<TripDTO> GetCompletedTrips()
        {
            throw new NotImplementedException();
        }

        public IList<TripDTO> GetScheduledTrips()
        {
            return _tripRepository.GetInitialisedTrips().Select(trip => new TripDTO
            {
                Id = trip.Id,
                AvailableSeat = trip.AvailableSeat,
                TripReference = trip.TripReference,
                TakeOffPoint = trip.TakeOffPoint,
                TakeOffTime = trip.TakeOffTime,
                LandingPoint = trip.LandingPoint,
                LandingTime = trip.LandingTime,
                BusId = trip.BusId,
                Price = trip.Price,
                Status = trip.Status,
                BusType = trip.Bus.BusType,


            }).ToList();
        }

        public IList<TripDTO> GetScheduledTripsByDate(DateTime dateTime)
        {
            return _tripRepository.GetTripsByDate(dateTime).Select(trip => new TripDTO
            {
                Id = trip.Id,
                AvailableSeat = trip.AvailableSeat,
                TripReference = trip.TripReference,
                TakeOffPoint = trip.TakeOffPoint,
                TakeOffTime = trip.TakeOffTime,
                LandingPoint = trip.LandingPoint,
                LandingTime = trip.LandingTime,
                BusId = trip.BusId,
                Price = trip.Price,
                Status = trip.Status,
                BusType = trip.Bus.BusType,


            }).ToList();
        }

        public IList<TripDTO> GetScheduledTripsByLocationByDate(Location from, Location to, DateTime date)
        {
            return _tripRepository.GetAvailableTrips(from, to, date).Select(trip => new TripDTO
            {
                Id = trip.Id,
                AvailableSeat = trip.AvailableSeat,
                TripReference = trip.TripReference,
                TakeOffPoint = trip.TakeOffPoint,
                TakeOffTime = trip.TakeOffTime,
                LandingPoint = trip.LandingPoint,
                LandingTime = trip.LandingTime,
                BusId = trip.BusId,
                Price = trip.Price,
                Status = trip.Status,
                BusType = trip.Bus.BusType,


            }).ToList();
        }

        public TripDTO GetTrip(int id)
        {
            var trip = _tripRepository.Get(id);
            return new TripDTO
            {
                Id = trip.Id,
                AvailableSeat = trip.AvailableSeat,
                TripReference = trip.TripReference,
                TakeOffPoint = trip.TakeOffPoint,
                TakeOffTime = trip.TakeOffTime,
                LandingPoint = trip.LandingPoint,
                LandingTime = trip.LandingTime,
                BusId = trip.BusId,
                Price = trip.Price,
                Status = trip.Status,
                BusType = trip.Bus.BusType,
            };
        }

        public IList<TripDTO> GetTrips()
        {
            return _tripRepository.GetAll().Select(trip => new TripDTO
            {
                Id = trip.Id,
                AvailableSeat = trip.AvailableSeat,
                TripReference = trip.TripReference,
                TakeOffPoint = trip.TakeOffPoint,
                TakeOffTime = trip.TakeOffTime,
                LandingPoint = trip.LandingPoint,
                LandingTime = trip.LandingTime,
                BusId = trip.BusId,
                Price = trip.Price,
                Status = trip.Status,
                BusType = trip.Bus.BusType,
               

            }).ToList();
        }

        public bool ScheduleTrip(CreateTripRequestModel model)
        {
            var bus = _busRepository.Get(model.BusId);
            var trip = new Trip
            {
                IsDeleted = false,
                BusId = model.BusId,
                DriverId = model.DriverId,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                TakeOffPoint = model.TakeOffPoint,
                TakeOffTime = model.TakeOffTime,
                LandingPoint = model.LandingPoint,
                Price = model.Price,
                TripReference = $"{Guid.NewGuid()}",
                LandingTime = model.LandingTime,
                AvailableSeat = bus.Capacity

            };
            _tripRepository.Create(trip);
            return true;
        }
    }
}
