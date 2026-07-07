using MedicalStore.Data;
using MedicalStore.Models;
using MedicalStore.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalStore.Controllers
{
    public class ReportsController : Controller
    {
        private readonly AppDbContext _context;

        public ReportsController(AppDbContext context)
        {
            _context = context;
        }

        // Main Reports Menu
        public IActionResult Index()
        {
            return View();
        }

        // Stock Report
        public async Task<IActionResult> StockReport()
        {
            var stocks = await _context.Stocks.ToListAsync();
            return View(stocks);
        }

        // Sales Report
        public async Task<IActionResult> SalesReport()
        {
            var sales = await _context.SellOrders
                .Include(s => s.Client)
                .Include(s => s.Items)
                .ToListAsync();
            return View(sales);
        }

        // Client Report
        public async Task<IActionResult> ClientReport()
        {
            var clients = await _context.Clients.ToListAsync();
            return View(clients);
        }

        // Revenue Report
        public async Task<IActionResult> RevenueReport()
        {
            var revenueData = await _context.SellOrders
                .Select(order => new RevenueReportViewModel
                {
                    OrderDate = order.OrderDate,
                    TotalRevenue = order.Items.Sum(i => i.Quantity * i.Price)
                })
                .ToListAsync();

            return View(revenueData);
        }
    }
}
