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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public BookingDTO BookTicket(CreateBookingRequestModel model)
        {
            var ticket = new Booking
            {
                IsDeleted = false,
                Address = model.Address,
                BookingReference = $"{Guid.NewGuid()}",
                BookingStatus = BookingStatus.Initialize,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                IsPaid = false,
                NextOfKin = model.NextOfKin,
                PassengerId = model.PassengerId,
                TripId = model.TripId
            };
           var booking = _bookingRepository.Create(ticket);
            return new BookingDTO
            {
                Id = booking.Id,
                PassengerId = booking.PassengerId,
                TripId = booking.TripId,
                BookingReference = booking.BookingReference,
               
            };
        }

        public BookingDTO GetBooking(int id)
        {
            var booking = _bookingRepository.Get(id);
            return new BookingDTO
            {
                Id = booking.Id,
                PassengerId = booking.PassengerId,
                TripId = booking.TripId,
                PassengerName = $"{booking.Passenger.FirstName} {booking.Passenger.FirstName}",
                BookingReference = booking.BookingReference,
                BusModel = booking.Trip.Bus.Model,
                BusType = booking.Trip.Bus.BusType,
                BookingStatus = booking.BookingStatus,
                TakeOffPoint = booking.Trip.TakeOffPoint,
                LandingPoint = booking.Trip.LandingPoint,
                TakeOffTime = booking.Trip.TakeOffTime,
                TripReference = booking.Trip.TripReference,
                Price = booking.Trip.Price,
                NextOfKin = booking.NextOfKin
            };
        }

        public IList<BookingDTO> GetBookingByTrips(int tripId)
        {
            return _bookingRepository.GetBookingsByTrip(tripId).Select(booking => new BookingDTO
            {
                Id = booking.Id,
                PassengerId = booking.PassengerId,
                TripId = booking.TripId,
                PassengerName = $"{booking.Passenger.FirstName} {booking.Passenger.FirstName}",
                BookingReference = booking.BookingReference,
                BusModel = booking.Trip.Bus.Model,
                BusType = booking.Trip.Bus.BusType,
                BookingStatus = booking.BookingStatus,
                TakeOffPoint = booking.Trip.TakeOffPoint,
                LandingPoint = booking.Trip.LandingPoint,
                TakeOffTime = booking.Trip.TakeOffTime,
                TripReference = booking.Trip.TripReference,
                Price = booking.Trip.Price,
                NextOfKin = booking.NextOfKin
            }).ToList();
        }

        public IList<BookingDTO> GetBookings()
        {
            return _bookingRepository.GetAll().Select(booking => new BookingDTO
            {
                Id = booking.Id,
                PassengerId = booking.PassengerId,
                TripId = booking.TripId,
                PassengerName = $"{booking.Passenger.FirstName} {booking.Passenger.FirstName}",
                BookingReference = booking.BookingReference,
                BusModel = booking.Trip.Bus.Model,
                BusType = booking.Trip.Bus.BusType,
                BookingStatus = booking.BookingStatus,
                TakeOffPoint = booking.Trip.TakeOffPoint,
                LandingPoint = booking.Trip.LandingPoint,
                TakeOffTime = booking.Trip.TakeOffTime,
                TripReference = booking.Trip.TripReference,
                Price = booking.Trip.Price,
                NextOfKin = booking.NextOfKin
            }).ToList();
        }

        public BookingDTO GetByReference(string reference)
        {
            var booking = _bookingRepository.GetByReference(reference);
            return new BookingDTO
            {
                Id = booking.Id,
                PassengerId = booking.PassengerId,
                TripId = booking.TripId,
                PassengerName = $"{booking.Passenger.FirstName} {booking.Passenger.FirstName}",
                BookingReference = booking.BookingReference,
                BusModel = booking.Trip.Bus.Model,
                BusType = booking.Trip.Bus.BusType,
                BookingStatus = booking.BookingStatus,
                TakeOffPoint = booking.Trip.TakeOffPoint,
                LandingPoint = booking.Trip.LandingPoint,
                TakeOffTime = booking.Trip.TakeOffTime,
                TripReference = booking.Trip.TripReference,
                Price = booking.Trip.Price,
                NextOfKin = booking.NextOfKin
            };
        }
    }
}
