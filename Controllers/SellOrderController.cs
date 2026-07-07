using MedicalStore.Data;
using MedicalStore.Models;
using MedicalStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedicalStore.Controllers
{
    public class SellOrderController : Controller
    {
        private readonly AppDbContext _context;

        public SellOrderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Clients = await _context.Clients.ToListAsync();
            ViewBag.Medicines = await _context.Stocks
                .Where(s => s.Quantity > 0)
                .Select(s => s.MedicineName)
                .Distinct()
                .ToListAsync();

            return View(new SellOrderViewModel { Items = new List<SellItemViewModel> { new SellItemViewModel() } });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitOrder(SellOrderViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Clients = await _context.Clients.ToListAsync();
                ViewBag.Medicines = await _context.Stocks.Select(s => s.MedicineName).Distinct().ToListAsync();
                return View("Create", model);
            }

            foreach (var item in model.Items)
            {
                var stock = await _context.Stocks.FirstOrDefaultAsync(s =>
                    s.MedicineName == item.MedicineName && s.Quantity >= item.Quantity);

                if (stock == null)
                {
                    ModelState.AddModelError("", $"Insufficient stock for {item.MedicineName}");
                    ViewBag.Clients = await _context.Clients.ToListAsync();
                    ViewBag.Medicines = await _context.Stocks.Select(s => s.MedicineName).Distinct().ToListAsync();
                    return View("Create", model);
                }

                stock.Quantity -= item.Quantity;
                _context.Stocks.Update(stock);
            }

            var order = new SellOrder
            {
                ClientId = model.ClientId,
                OrderDate = DateTime.Now,
                Items = model.Items.Select(i => new SellItem
                {
                    MedicineName = i.MedicineName,
                    Quantity = i.Quantity,
                    Price = i.Price
                }).ToList()
            };

            _context.SellOrders.Add(order);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Order placed successfully!";
            return RedirectToAction("Create");
        }

        [HttpPost]
        public IActionResult CancelOrder()
        {
            TempData["CancelMessage"] = "Order canceled.";
            return RedirectToAction("Create");
        }
    }
}
