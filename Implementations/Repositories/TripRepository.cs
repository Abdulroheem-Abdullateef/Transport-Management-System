using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Context;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Enums;
using TransportManagementSystem.Interfaces.Repositories;

namespace TransportManagementSystem.Implementations.Repositories
{
    public class TripRepository : ITripRepository
    {
        private readonly ApplicationContext _context;
        public TripRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Trip Create(Trip trip)
        {
            _context.Trips.Add(trip);
            _context.SaveChanges();
            return trip;
        }

        public void Delete(Trip trip)
        {
            _context.Trips.Remove(trip);
            _context.SaveChanges();
        }

        public bool ExistById(int id)
        {
            return _context.Trips.Any(t => t.Id == id);
        }

        public Trip Get(int id)
        {
            return _context.Trips.Include(t => t.Bus).Include(t => t.Bookings).ThenInclude(b => b.Passenger).SingleOrDefault(t => t.Id == id);
        }

        public IList<Trip> GetAll()
        {
            return _context.Trips.Include(t => t.Bus).Include(t => t.Bookings).ThenInclude(b => b.Passenger).ToList();
        }

        public IList<Trip> GetAvailableTrips(Location from, Location to, DateTime date)
        {
            return _context.Trips.Include(t => t.Bus).Include(t => t.Bookings).Where(s => s.TakeOffPoint == from && s.LandingPoint == to && s.TakeOffTime.Date == date && s.AvailableSeat > 0 && s.Status == TripStatus.Initialize).ToList();
        }

        public Trip GetByReference(string reference)
        {
            throw new NotImplementedException();
        }

        public IList<Trip> GetCompletedTrips()
        {
            return _context.Trips.Include(t => t.Bus).Include(t => t.Bookings).ThenInclude(b => b.Passenger).Where(t => t.Status == TripStatus.Completed).ToList();
        }

        public IList<Trip> GetInitialisedTrips()
        {
            return _context.Trips.Include(t => t.Bus).Include(t => t.Bookings).ThenInclude(b => b.Passenger).Where(t => t.Status == TripStatus.Initialize).ToList();
        }

        public IList<Trip> GetTripsByBus(string registrationNumber)
        {
            return _context.Trips.Include(t => t.Bus).Include(t => t.Bookings).ThenInclude(b => b.Passenger).Where(t => t.Bus.RegistrationNumber == registrationNumber).ToList();
        }

        public IList<Trip> GetTripsByDate(DateTime date)
        {
            return _context.Trips.Include(t => t.Bus).Include(t => t.Bookings).ThenInclude(b => b.Passenger).Where(t => t.TakeOffTime.Date == date.Date).ToList();
        }

        public IList<Trip> GetTripsByDateAndLocation(Location from, Location to, DateTime date)
        {
            throw new NotImplementedException();
        }

        public IList<Trip> GetTripsByDriver(int driverId)
        {
            throw new NotImplementedException();
        }

        public Trip Update(Trip trip)
        {
            _context.Trips.Update(trip);
            _context.SaveChanges();
            return trip;
        }
    }
}
