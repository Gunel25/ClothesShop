using ClothesShop.DAL;
using ClothesShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ColorController : Controller
    {
        private readonly AppDbContext appDbContext;
        public ColorController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public IActionResult GetColor()
        {
            return View(appDbContext.Colors.ToList());
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Color color)
        {
            appDbContext.Colors.Add(color);
            appDbContext.SaveChanges();
            return RedirectToAction("GetColor");
        }
        public IActionResult Delete(int id)
        {
            var c = appDbContext.Colors.Find(id);
            if (c != null)
            {
                appDbContext.Colors.Remove(c);
            }
            appDbContext.SaveChanges();
            return RedirectToAction("GetColor");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(appDbContext.Colors.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(Color color)
        {
            var c = appDbContext.Colors.Find(color.Id);
            if (c != null)
            {
                c.Name = color.Name;
                c.Code = color.Code;
                c.IsActive = color.IsActive;
            }
            appDbContext.SaveChanges();
            return RedirectToAction("GetColor");
        }
        public IActionResult Activation(int id)
        {
            var color = appDbContext.Colors.Find(id);
            if (color != null)
            {
                if (color.IsActive)
                {
                    color.IsActive = false;
                }
                else
                {
                    color.IsActive = true;
                }
                appDbContext.SaveChanges();
            }
            return RedirectToAction("GetColor");
        }
    }
}

