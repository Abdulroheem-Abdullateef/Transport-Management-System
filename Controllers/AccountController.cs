using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TransportManagementSystem.Enums;
using TransportManagementSystem.Interfaces.Services;
using TransportManagementSystem.Models;

namespace TransportManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            return View(_userService.GetUsers());
        }

        public IActionResult Admins()
        {
            return View(_userService.GetAdmins());
        }

        public IActionResult Drivers()
        {
            return View(_userService.GetDrivers());
        }
        public IActionResult Passengers()
        {
            return View(_userService.GetPassengers());
        }

        public IActionResult Detail(int id)
        {
            return View(_userService.GetUser(id));
        }

        public IActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterAdmin(CreateUserRequestModel model)
        {
            _userService.RegisterAdmin(model);
            return RedirectToAction("Admins");
        }

        public IActionResult RegisterDriver()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterDriver(CreateUserRequestModel model)
        {
            _userService.RegisterDriver(model);
            return RedirectToAction("Drivers");
        }

        public IActionResult RegisterPassenger()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterPassenger(CreateUserRequestModel model)
        {
            _userService.RegisterPassenger(model);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequestModel model)
        {
            var user = _userService.Login(model);
            if (user != null && user.UserType == UserType.Admin)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Admin"),
                   
                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Index", "Account");
            }
            else if (user != null && user.UserType == UserType.Driver)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Driver"),

                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Profle");
            }
            else if (user != null && user.UserType == UserType.Passenger)
            {

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, $"{user.FirstName} {user.LastName}"),
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim("Id", user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, "Passenger"),

                };
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authenticationProperties = new AuthenticationProperties();
                var principal = new ClaimsPrincipal(claimsIdentity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, authenticationProperties);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.error = "Invalid username or password";
                return View();
            }

        }




        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }


    }
}
