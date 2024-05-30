using ClothesShop.DAL;
using ClothesShop.Extensions;
using ClothesShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class DashBoardController : Controller
    {
        private readonly SignInManager<ProgramUser> _signInManager;
        public DashBoardController(AppDbContext _appDbContext,  SignInManager<ProgramUser> signInManager)
        {
        
            _signInManager = signInManager;
          
        }
        public IActionResult Index()
        {
            List<Slider> list = new List<Slider>();
            return View();
        }
      public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new { area = "" }); // alanı belirtmiyoruz
        }
    }
}
