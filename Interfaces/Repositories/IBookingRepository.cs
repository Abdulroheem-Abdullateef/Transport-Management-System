using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Entities;

namespace TransportManagementSystem.Interfaces.Repositories
{
    public interface IBookingRepository
    {
        Booking Create(Booking booking);

        Booking Get(int id);

        IList<Booking> GetAll();

        Booking GetByReference(string reference);

        IList<Booking> GetBookingsByTrip(int tripId);

        Booking Update(Booking booking);

        void Delete(Booking booking);

        bool ExistById(int id);

        bool ExistByReference(string reference);
    }
}
