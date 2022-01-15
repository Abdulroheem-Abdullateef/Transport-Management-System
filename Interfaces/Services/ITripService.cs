using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Interfaces.Services
{
    public interface ITripService
    {
        bool ScheduleTrip(CreateTripRequestModel model);

        TripDTO GetTrip(int id);

        IList<TripDTO> GetTrips();

        IList<TripDTO> GetScheduledTrips();

        IList<TripDTO> GetScheduledTripsByDate(DateTime dateTime);

        IList<TripDTO> GetScheduledTripsByLocationByDate(Location from, Location to, DateTime date);

        IList<TripDTO> GetCompletedTrips();
    }
}
