using Microsoft.AspNetCore.Mvc;

namespace ClothesShopAPI.Controllers
{
    public class SliderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
