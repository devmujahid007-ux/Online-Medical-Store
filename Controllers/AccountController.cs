using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MedicalStore.Models; // Adjust if needed

namespace MedicalStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly List<Admin> _users = new()
        {
            new Admin { Username = "admin", Password = "admin123" }
        };

        [HttpGet]
        public IActionResult Login()
        {
            return View(); // <- this must match the View name: "Login.cshtml"
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", username);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid username or password";
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
