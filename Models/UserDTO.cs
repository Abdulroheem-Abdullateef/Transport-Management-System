using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;

namespace TransportManagementSystem.Models
{
    public class UserDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public AccountStatus Status { get; set; }

        public UserType UserType { get; set; }

        public List<BookingDTO> Bookings { get; set; } = new List<BookingDTO>();
    }

    public class CreateUserRequestModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Country { get; set; }

        public UserType UserType { get; set; }

        public string Password { get; set; }
    }

    public class LoginRequestModel
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}
