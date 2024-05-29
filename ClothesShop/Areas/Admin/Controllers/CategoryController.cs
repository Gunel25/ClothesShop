using ClothesShop.DAL;
using ClothesShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {

        private readonly AppDbContext appDbContext;
        public CategoryController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public IActionResult Index()
        {
            return View(appDbContext.Categories.Where(x=>x.IsActive==true).ToList());
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            if (!ModelState.IsValid)
            {
                //  ViewBag.Category = appDbContext.Categories.ToList();
                return View(model);
            }

            appDbContext.Categories.Add(model);
            appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult Edit(int id)
        {
            var category = appDbContext.Categories.Find(id); // Kategori verilerini veritabanından al
            return Json(category); // Kategori verilerini JSON formatında dön
        }

        [HttpPost]
        public IActionResult Edit(Category model)
        {
            // // ViewBag.Category = appDbContext.Categories.ToList();
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            appDbContext.Categories.Update(model);
            appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public JsonResult Delete(int id)
        {
            if (id == 0)
            {
                return Json(new
                {
                    status = 400
                });
            }
            var model = appDbContext.Categories.Find(id);
            if (model != null)
            {
                model.IsActive = false;
              //  appDbContext.Categories.Remove(model);
                appDbContext.SaveChanges();
            }
            return Json(new
            {
                status = 200
            });
        }

    }
}
