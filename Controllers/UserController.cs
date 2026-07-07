using Microsoft.AspNetCore.Mvc;
using MedicalStore.Models;
using MedicalStore.Data;
using MedicalStore.Services;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService;

        public UserController(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "User added successfully.";

                // ✅ Send real-time email
                string subject = "Account Created Successfully";
                string body = $"<p>Hello {user.Username},</p><p>Your account has been created successfully!</p>";

                try
                {
                    await _emailService.SendEmailAsync(user.Email, subject, body);
                }
                catch (Exception ex)
                {
                    TempData["EmailError"] = $"Email sending failed: {ex.Message}";
                }

                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: User/Edit/5
        public IActionResult Edit(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, User updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(updatedUser);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "User updated successfully.";
                return RedirectToAction(nameof(Index));
            }
            return View(updatedUser);
        }

        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "User deleted successfully.";
            }
            return RedirectToAction("Index");
        }
    }
}
