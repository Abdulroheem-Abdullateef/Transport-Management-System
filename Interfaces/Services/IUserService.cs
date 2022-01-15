using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Interfaces.Services
{
    public interface IUserService
    {
        bool RegisterAdmin(CreateUserRequestModel model);
        bool RegisterDriver(CreateUserRequestModel model);
        bool RegisterPassenger(CreateUserRequestModel model);
        UserDTO GetUser(int id);
        UserDTO GetByEmail(string email);
        IList<UserDTO> GetUsers();
        IList<UserDTO> GetPassengers();
        IList<UserDTO> GetAdmins();
        IList<UserDTO> GetDrivers();
        UserDTO Login(LoginRequestModel model);
    }
}
