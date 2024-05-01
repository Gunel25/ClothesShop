using ClothesShop.DAL;
using ClothesShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext appDbContext;
        public ProductsController( AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public IActionResult Index()
        {
            return View(appDbContext.Products.Include(x => x.Category).ToList());
        }
        public IActionResult Create()
        {
           ViewBag.Category= appDbContext.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Products model)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Category = appDbContext.Categories.ToList();
                return View(model);
            }

            appDbContext.Products.Add(model);
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
            var model = appDbContext.Products.Find(id);
            if (model != null)
            {
                appDbContext.SaveChanges();
            }
            return Json(new
            {
                status = 200
            });
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Category = appDbContext.Categories.ToList();
          var model = appDbContext.Products.FirstOrDefault(x=>x.Id == id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Products products)
        {
            ViewBag.Category = appDbContext.Categories.ToList();
            if (!ModelState.IsValid)
            {
                return View(products);
            }
            appDbContext.Products.Update(products);
            appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }

    }


}
