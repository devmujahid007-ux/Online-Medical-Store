using MedicalStore.Data;
using MedicalStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace MedicalStore.Controllers
{
    public class StockController : Controller
    {
        private readonly AppDbContext _context;

        public StockController(AppDbContext context)
        {
            _context = context;
        }

        // Ensure user is logged in
        private bool IsLoggedIn() => !string.IsNullOrEmpty(HttpContext.Session.GetString("Username"));

        public IActionResult Index()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            var stocks = _context.Stocks.ToList();
            return View(stocks);
        }

        // GET: Stock/Create
        public IActionResult Create()
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            return View();
        }

        // POST: Stock/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Stock stock)
        {

            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                _context.Stocks.Add(stock);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // GET: Stock/Edit/5
        public IActionResult Edit(int? id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id == null)
                return NotFound();

            var stock = _context.Stocks.Find(id);
            if (stock == null)
                return NotFound();

            return View(stock);
        }

        // POST: Stock/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Stock stock)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id != stock.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stock);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Stocks.Any(e => e.Id == id))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(stock);
        }

        // GET: Stock/Delete/5
        public IActionResult Delete(int? id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            if (id == null)
                return NotFound();

            var stock = _context.Stocks.Find(id);
            if (stock == null)
                return NotFound();

            return View(stock);
        }

        // POST: Stock/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (!IsLoggedIn())
                return RedirectToAction("Login", "Account");

            var stock = _context.Stocks.Find(id);
            if (stock != null)
            {
                _context.Stocks.Remove(stock);
                _context.SaveChanges();

                // Set success message in TempData
                TempData["SuccessMessage"] = "Stock deleted successfully.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
