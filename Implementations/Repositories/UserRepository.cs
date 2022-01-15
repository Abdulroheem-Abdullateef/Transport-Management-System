using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Context;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Enums;
using TransportManagementSystem.Interfaces.Repositories;

namespace TransportManagementSystem.Implementations.Repositories
{

    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        public bool ExistByEmail(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public bool ExistById(int id)
        {
            return _context.Users.Any(u => u.Id == id);
        }

        public User Get(int id)
        {
            return _context.Users.Include(u => u.Bookings).SingleOrDefault(u => u.Id == id);
        }

        public IList<User> GetAdmins()
        {
            return _context.Users.Include(u => u.Bookings).Where(u => u.UserType == UserType.Admin).ToList();
        }

        public IList<User> GetAll()
        {
            return _context.Users.Include(u => u.Bookings).ToList();
        }

        public User GetByEmail(string email)
        {
            return _context.Users.Include(u => u.Bookings).ThenInclude(b => b.Trip).ThenInclude(t => t.Bus).SingleOrDefault(u => u.Email == email);
        }

        public IList<User> GetDrivers()
        {
            return _context.Users.Include(u => u.Bookings).Where(u => u.UserType == UserType.Driver).ToList();
        }

        public IList<User> GetPassengers()
        {
            return _context.Users.Include(u => u.Bookings).Where(u => u.UserType == UserType.Passenger).ToList();
        }

        public User Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
