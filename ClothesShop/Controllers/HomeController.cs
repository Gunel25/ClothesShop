using ClothesShop.DAL;
using ClothesShop.Models;
using ClothesShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ClothesShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext appDbContext;
        public HomeController(ILogger<HomeController> logger, AppDbContext _appDbContext)
        {
            _logger = logger;
            appDbContext = _appDbContext;
        }

        public IActionResult Index()
        {
            List<Slider> list = new List<Slider>(); 
            return View(appDbContext.Sliders.Where(x=>x.IsCheck !=false).ToList());
        }
        public IActionResult account_edit()
        {
            return View();
        }
        public IActionResult error()
        {
            return View("404");
        }
        public IActionResult account_orders()
        {
            return View();
        }
        public IActionResult account_wishlist()
        {
            return View();
        }
        public IActionResult blog_list2()
        {
        return View();
        }
        public IActionResult blog_single()
        {
            return View();
        }
        public IActionResult contact()
        {
            return View();
        }
        public IActionResult login_register()
        {
            return View();
        }
        public IActionResult product2_variable()
        {
            return View();
        }
        public IActionResult shop_cart()
        {
            return View();
        }
        public IActionResult shop_checkout()
        {
            return View();
        }
        public IActionResult shop_order_complete()
        {
            return View();
        }
        public IActionResult shop5()
        {
            ShopVM  model = new ShopVM
            {
                categories = appDbContext.Categories.Where(x =>x.IsActive==true).ToList(),
                products = appDbContext.Products.ToList(),
            };
            return View(model);
        }
      
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
