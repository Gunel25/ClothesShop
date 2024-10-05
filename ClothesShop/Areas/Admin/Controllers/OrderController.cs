using ClothesShop.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ClothesShop.Models;
using ClothesShop.ViewModels;
using Microsoft.EntityFrameworkCore;


namespace ClothesShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly AppDbContext appDbContext;
        private IWebHostEnvironment _env;

        public OrderController(AppDbContext _appDbContext, IWebHostEnvironment env)
        {
            appDbContext = _appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            var orders = appDbContext.Orders
           .Include(o => o.OrderItems)
               .ThenInclude(oi => oi.Products)
           .OrderByDescending(o => o.Date) // Tarihe göre sıralama, en yeni tarihler en son
           .ToList();

            return View(orders);
        }
    }
} 

