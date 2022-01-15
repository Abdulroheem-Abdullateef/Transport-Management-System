using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Interfaces.Services
{
    public interface IBusService
    {
        bool RegisterBus(CreateBusRequestModel model);

        BusDTO GetBus(int id);

        IList<BusDTO> GetBuses();

        IList<BusDTO> GetAvailableBuses();
    }
}
