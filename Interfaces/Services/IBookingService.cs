using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Interfaces.Services
{
    public interface IBookingService
    {
        BookingDTO BookTicket(CreateBookingRequestModel model);

        BookingDTO GetBooking(int id);

        BookingDTO GetByReference(string reference);

        IList<BookingDTO> GetBookings();

        IList<BookingDTO> GetBookingByTrips(int tripId);
    }
}
