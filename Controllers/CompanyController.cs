using Microsoft.AspNetCore.Mvc;
using MedicalStore.Data;
using MedicalStore.Models;
using System.Linq;

namespace MedicalStore.Controllers
{
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;

        public CompanyController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Company
        public IActionResult Index()
        {
            var companies = _context.Companies.ToList();
            return View(companies);
        }

        // GET: Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Companies.Add(company);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Company added successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Company/Edit/5
        public IActionResult Edit(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null) return NotFound();
            return View(company);
        }

        // POST: Company/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Company company)
        {
            if (ModelState.IsValid)
            {
                _context.Companies.Update(company);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Company updated successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(company);
        }

        // GET: Company/Delete/5
        public IActionResult Delete(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null) return NotFound();
            return View(company);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var company = _context.Companies.Find(id);
            if (company == null) return NotFound();
            _context.Companies.Remove(company);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Company deleted successfully!";
            return RedirectToAction(nameof(Index));
        }
    }
}
