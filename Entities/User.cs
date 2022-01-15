using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;

namespace TransportManagementSystem.Entities
{
    public class User : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public AccountStatus Status { get; set; }

        public string Password { get; set; }

        public UserType UserType { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
