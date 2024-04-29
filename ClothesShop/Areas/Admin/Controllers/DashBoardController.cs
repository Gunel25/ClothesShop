using ClothesShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            List<Slider> list = new List<Slider>();
            return View();
        }
    }
}
