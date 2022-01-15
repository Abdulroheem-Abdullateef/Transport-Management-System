using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Entities;

namespace TransportManagementSystem.Interfaces.Repositories
{
    public interface IBusRepository
    {
        Bus Create(Bus bus);

        Bus Get(int id);

        IList<Bus> GetAll();

        Bus GetByRegistrationNumber(string registrationNumber);

        IList<Bus> GetAvailableBuses();

        Bus Update(Bus bus);

        void Delete(Bus bus);

        bool ExistById(int id);

        bool ExistByRegNumber(string regNum);
    }
}
