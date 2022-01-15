using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Context;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Interfaces.Repositories;

namespace TransportManagementSystem.Implementations.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationContext _context;
        public BookingRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Booking Create(Booking booking)
        {
            _context.Bookings.Add(booking);
            _context.SaveChanges();
            return booking;
        }

        public void Delete(Booking booking)
        {
            throw new NotImplementedException();
        }

        public bool ExistById(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExistByReference(string reference)
        {
            throw new NotImplementedException();
        }

        public Booking Get(int id)
        {
            var booking = _context.Bookings.Include(b => b.Passenger).Include(b => b.Trip).ThenInclude(t => t.Bus).SingleOrDefault(b => b.Id == id);
            return booking;
        }

        public IList<Booking> GetAll()
        {
            var bookings = _context.Bookings.Include(b => b.Passenger).Include(b => b.Trip).ThenInclude(t => t.Bus).ToList();
            return bookings;
        }

        public IList<Booking> GetBookingsByTrip(int tripId)
        {
            var bookings = _context.Bookings.Include(b => b.Passenger).Include(b => b.Trip).ThenInclude(t => t.Bus).Where(b => b.Id == tripId).ToList();
            return bookings;
        }

        public Booking GetByReference(string reference)
        {
            var booking = _context.Bookings.Include(b => b.Passenger).Include(b => b.Trip).ThenInclude(t => t.Bus).SingleOrDefault(b => b.BookingReference == reference);
            return booking;
        }

        public Booking Update(Booking booking)
        {
            throw new NotImplementedException();
        }
    }
}
