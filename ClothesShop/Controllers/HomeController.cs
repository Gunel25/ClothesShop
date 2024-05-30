using ClothesShop.DAL;
using ClothesShop.Migrations;
using ClothesShop.Models;
using ClothesShop.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ClothesShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext appDbContext;
        public HomeController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }

        //public IActionResult Index()
        //{
        //  HomeVM homevm = new HomeVM();
        //    {
        //        Products = appDbContext.Products.Where(x => x.IsStock).ToList();
        //        Sliders = appDbContext.Sliders.Where(x => x.IsCheck).ToList();
        //    }
        //    return View(homevm);
        //}
        public IActionResult Index()
        {
            HomeVM homevm = new HomeVM();

                homevm.Products = appDbContext.Products.Where(x => x.IsStock).ToList();
                homevm.Sliders = appDbContext.Sliders.Where(x => x.IsCheck).ToList();
                return View(homevm);
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
        //public IActionResult product2_variable(int id)
        //{
        //  var  products = appDbContext.Products.Include(x=>x.Images).Include(x=>x.ColorToProducts).ThenInclude(y=>y.Color).Include(x=>x.SizeToProducts).ThenInclude(y=>y.Size).FirstOrDefault(x=>x.Id==id);
        //    ManyModels model = new ManyModels
        //    {


        //    };
        //    return View(model);
        //}
        //public IActionResult product2_detail(int id)
        //{
        //    var product = appDbContext.Products
        //        .Include(x => x.Images)
        //        .Include(x => x.ColorToProducts).ThenInclude(y => y.Color)
        //        .Include(x => x.SizeToProducts).ThenInclude(y => y.Size)
        //        .FirstOrDefault(x => x.Id == id);

        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    var colors = appDbContext.Colors.ToList();
        //    var sizes = appDbContext.Sizes.ToList();

        //    ManyModels model = new ManyModels
        //    {
        //        Products = product,
        //        Colors = colors,
        //        Sizes = sizes
        //    };

        //    return View(model);
        //}

        //public IActionResult shop_cart()
        //{
        //    return View();
        //}
        public IActionResult shop_checkout()
        {
            return View();
        }
        public IActionResult shop_order_complete()
        {
            return View();
        }
        //public IActionResult shop5()
        //{
        //    ShopVM  model = new ShopVM
        //    {
        //        categories = appDbContext.Categories.Where(x =>x.IsActive==true).ToList(),
        //        products = appDbContext.Products.ToList(),
        //    };
        //    return View(model);
        //}
      
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
