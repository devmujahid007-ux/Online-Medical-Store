using MedicalStore.Data;
using MedicalStore.Models;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProductApiController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductApiController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        var products = _context.Products.ToList();
        return Ok(products);
    }

    [HttpPost]
    public IActionResult AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return Ok(product);
    }

    // PUT, DELETE as needed
}
