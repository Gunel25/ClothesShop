using ClothesShop.DAL;
using ClothesShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClothesShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly AppDbContext appDbContext;
        public CategoryController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public IActionResult Index()
        {
            return View(appDbContext.Categories.ToList());
        }

        [HttpPost]
        public IActionResult Create(Category model)
        {
            //if (!ModelState.IsValid)
            //{
            //  //  ViewBag.Category = appDbContext.Categories.ToList();
            //    return View(model);
            //}

            appDbContext.Categories.Add(model);
            appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Edit(Category model)
        {
          //  ViewBag.Category = appDbContext.Categories.ToList();
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}
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
                appDbContext.SaveChanges();
            }
            return Json(new
            {
                status = 200
            });
        }

    }
}
