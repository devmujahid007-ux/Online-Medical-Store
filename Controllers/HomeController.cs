using Microsoft.AspNetCore.Mvc;
using MedicalStore.Data;
using System.Linq;
using Newtonsoft.Json;

namespace MedicalStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        // ✅ Constructor with proper dependency injection
        public HomeController(AppDbContext context)
        {
            _context = context; // 👈 Assign it here
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Index()
    {
        var totalStock = _context.Stocks.Sum(s => s.Quantity);
        var totalClients = _context.Clients.Count();
        var totalSales = _context.SellOrders
            .SelectMany(o => o.Items)
            .Sum(i => i.Quantity * i.Price);

        // For graph (optional)
        var monthlySales = _context.SellOrders
            .GroupBy(o => o.OrderDate.Month)
            .Select(g => new {
                Month = g.Key,
                Total = g.SelectMany(o => o.Items).Sum(i => i.Quantity * i.Price)
            })
            .OrderBy(x => x.Month)
            .ToList();

        ViewBag.TotalStock = totalStock;
        ViewBag.TotalSales = totalSales;
        ViewBag.TotalClients = totalClients;
        ViewBag.SalesLabelsJson = JsonConvert.SerializeObject(monthlySales.Select(x => "Month " + x.Month));
        ViewBag.SalesDataJson = JsonConvert.SerializeObject(monthlySales.Select(x => x.Total));

        return View();
    }
    }
}
