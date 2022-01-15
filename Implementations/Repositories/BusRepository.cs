using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Context;
using TransportManagementSystem.Entities;
using TransportManagementSystem.Interfaces.Repositories;

namespace TransportManagementSystem.Implementations.Repositories
{

    public class BusRepository : IBusRepository
    {
        private readonly ApplicationContext _context;
        public BusRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Bus Create(Bus bus)
        {
            _context.Buses.Add(bus);
            _context.SaveChanges();
            return bus;
        }

        public void Delete(Bus bus)
        {
            _context.Buses.Remove(bus);
            _context.SaveChanges();
        }

        public bool ExistById(int id)
        {
            return _context.Buses.Any(b => b.Id == id);
        }

        public bool ExistByRegNumber(string regNum)
        {
            return _context.Buses.Any(b => b.RegistrationNumber == regNum);
        }

        public Bus Get(int id)
        {
            return _context.Buses.Include(b => b.Trips).SingleOrDefault(b => b.Id == id);
        }

        public IList<Bus> GetAll()
        {
            return _context.Buses.Include(b => b.Trips).Where(b => b.IsDeleted == false).ToList();
        }

        public IList<Bus> GetAvailableBuses()
        {
            return _context.Buses.Include(b => b.Trips).Where(b => b.AvailabilityStatus == true && b.TripStatus == true && b.IsDeleted == false).ToList();
        }

        public Bus GetByRegistrationNumber(string registrationNumber)
        {
            return _context.Buses.Include(b => b.Trips).SingleOrDefault(b => b.RegistrationNumber == registrationNumber);
        }

        public Bus Update(Bus bus)
        {
            _context.Buses.Update(bus);
            _context.SaveChanges();
            return bus;
        }
    }
}
