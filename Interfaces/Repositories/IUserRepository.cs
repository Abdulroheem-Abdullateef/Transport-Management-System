
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Enums;

namespace TransportManagementSystem.Interfaces.Repositories
{
   public interface IUserRepository
    {
        User Create(User user);

        User Get(int id);

        User GetByEmail(string email);

        IList<User> GetAll();

        IList<User> GetPassengers();

        IList<User> GetAdmins();

        IList<User> GetDrivers();

        User Update(User user);

        void Delete(User user);

        bool ExistById(int id);

        bool ExistByEmail(string email);
    }
}
