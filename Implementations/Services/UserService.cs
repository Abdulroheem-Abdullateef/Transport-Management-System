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
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IList<UserDTO> GetAdmins()
        {
            return _userRepository.GetAdmins().Select(user => new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Country = user.Country,
                Status = user.Status,
                UserType = user.UserType
            }).ToList();
        }

        public UserDTO GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IList<UserDTO> GetDrivers()
        {
            return _userRepository.GetDrivers().Select(user => new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Country = user.Country,
                Status = user.Status,
                UserType = user.UserType
            }).ToList();
        }

        public IList<UserDTO> GetPassengers()
        {
            return _userRepository.GetDrivers().Select(user => new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Country = user.Country,
                Status = user.Status,
                UserType = user.UserType,
                Bookings = user.Bookings.Select(booking => new BookingDTO
                {
                    Id = booking.Id,
                    BookingReference = booking.BookingReference,
                    Address = booking.Address,
                    BusId = booking.Trip.BusId,
                    BusModel = booking.Trip.Bus.Model,
                    BusType = booking.Trip.Bus.BusType,
                    DriverId = booking.Trip.DriverId,
                    DriverName = $"{booking.Trip.Driver.FirstName} {booking.Trip.Driver.LastName}",
                    TakeOffPoint = booking.Trip.TakeOffPoint,
                    LandingPoint = booking.Trip.LandingPoint,
                    TakeOffTime = booking.Trip.TakeOffTime,
                    LandingTime = booking.Trip.LandingTime,
                    Price = booking.Trip.Price,
                    TripReference = booking.Trip.TripReference,
                    RegistrationNumber = booking.Trip.Bus.RegistrationNumber

                }).ToList()
            }).ToList();
        }

        public UserDTO GetUser(int id)
        {
            var user = _userRepository.Get(id);
            return new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Country = user.Country,
                Status = user.Status,
                UserType = user.UserType,
                Bookings = user.Bookings.Select(booking => new BookingDTO
                {
                    Id = booking.Id,
                    BookingReference = booking.BookingReference,
                    Address = booking.Address,
                    BusId = booking.Trip.BusId,
                    BusModel = booking.Trip.Bus.Model,
                    BusType = booking.Trip.Bus.BusType,
                    DriverId = booking.Trip.DriverId,
                    DriverName = $"{booking.Trip.Driver.FirstName} {booking.Trip.Driver.LastName}",
                    TakeOffPoint = booking.Trip.TakeOffPoint,
                    LandingPoint = booking.Trip.LandingPoint,
                    TakeOffTime = booking.Trip.TakeOffTime,
                    LandingTime = booking.Trip.LandingTime,
                    Price = booking.Trip.Price,
                    TripReference = booking.Trip.TripReference,
                    RegistrationNumber = booking.Trip.Bus.RegistrationNumber

                }).ToList()
            };
        }

        public IList<UserDTO> GetUsers()
        {
            return _userRepository.GetAll().Select(user => new UserDTO
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                Country = user.Country,
                Status = user.Status,
                UserType = user.UserType,
                Bookings = user.Bookings.Select(booking => new BookingDTO
                {
                    Id = booking.Id,
                    BookingReference = booking.BookingReference,
                    Address = booking.Address,
                    BusId = booking.Trip.BusId,
                    BusModel = booking.Trip.Bus.Model,
                    BusType = booking.Trip.Bus.BusType,
                    DriverId = booking.Trip.DriverId,
                    DriverName = $"{booking.Trip.Driver.FirstName} {booking.Trip.Driver.LastName}",
                    TakeOffPoint = booking.Trip.TakeOffPoint,
                    LandingPoint = booking.Trip.LandingPoint,
                    TakeOffTime = booking.Trip.TakeOffTime,
                    LandingTime = booking.Trip.LandingTime,
                    Price = booking.Trip.Price,
                    TripReference = booking.Trip.TripReference,
                    RegistrationNumber = booking.Trip.Bus.RegistrationNumber

                }).ToList()
            }).ToList();
        }

        public bool RegisterAdmin(CreateUserRequestModel model)
        {
            var userExist = _userRepository.ExistByEmail(model.Email);
            if (!userExist)
            {
                var admin = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Password = model.Password,
                    Country = model.Country,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    IsDeleted = false,
                    Status = AccountStatus.ACTIVE,
                    UserType = UserType.Admin
                };
                _userRepository.Create(admin);
            }
            return true;
        }

        public bool RegisterDriver(CreateUserRequestModel model)
        {
            var userExist = _userRepository.ExistByEmail(model.Email);
            if (!userExist)
            {
                var driver = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Password = model.Password,
                    Country = model.Country,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    IsDeleted = false,
                    Status = AccountStatus.ACTIVE,
                    UserType = UserType.Driver
                };
                _userRepository.Create(driver);
            }
            return true;
        }

        public bool RegisterPassenger(CreateUserRequestModel model)
        {
            var userExist = _userRepository.ExistByEmail(model.Email);
            if (!userExist)
            {
                var passenger = new User
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Password = model.Password,
                    Country = model.Country,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    IsDeleted = false,
                    Status = AccountStatus.ACTIVE,
                    UserType = UserType.Passenger
                };
                _userRepository.Create(passenger);
            }
            return true;
        }

        public UserDTO Login(LoginRequestModel model)
        {
            var user = _userRepository.GetByEmail(model.Email);
            if (user == null || user.Password != model.Password)
            {
                return null;
            }
            else
            {
                return new UserDTO
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Country = user.Country,
                    Status = user.Status,
                    UserType = user.UserType,
                    Bookings = user.Bookings.Select(booking => new BookingDTO
                    {
                        Id = booking.Id,
                        BookingReference = booking.BookingReference,
                        Address = booking.Address,
                        BusId = booking.Trip.BusId,
                        BusModel = booking.Trip.Bus.Model,
                        BusType = booking.Trip.Bus.BusType,
                        DriverId = booking.Trip.DriverId,
                      
                        TakeOffPoint = booking.Trip.TakeOffPoint,
                        LandingPoint = booking.Trip.LandingPoint,
                        TakeOffTime = booking.Trip.TakeOffTime,
                        LandingTime = booking.Trip.LandingTime,
                        Price = booking.Trip.Price,
                        TripReference = booking.Trip.TripReference,
                        RegistrationNumber = booking.Trip.Bus.RegistrationNumber

                    }).ToList()
                };
            }
        }
     }
}
