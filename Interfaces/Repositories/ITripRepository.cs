
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Enums;

namespace TransportManagementSystem.Interfaces.Repositories
{
    public interface ITripRepository
    {
        Trip Create(Trip trip);

        Trip Get(int id);

        Trip GetByReference(string reference);

        IList<Trip> GetAll();

        Trip Update(Trip trip);

        void Delete(Trip trip);

        bool ExistById(int id);

        IList<Trip> GetTripsByDateAndLocation(Location from, Location to, DateTime date);

        IList<Trip> GetAvailableTrips(Location from, Location to, DateTime date);

        IList<Trip> GetTripsByDriver(int driverId);

        IList<Trip> GetInitialisedTrips();
        IList<Trip> GetTripsByBus(string registrationNumber);

        IList<Trip> GetTripsByDate(DateTime date);

        IList<Trip> GetCompletedTrips();

    }
}
