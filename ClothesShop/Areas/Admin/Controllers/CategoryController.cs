using ClothesShop.DAL;
using ClothesShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public JsonResult Edit(int id)
        {
            var category = appDbContext.Categories.Find(id); // Kategori verilerini veritabanından al

        

            return Json(category); // Kategori verilerini JSON formatında dön
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(Category category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        appDbContext.Entry(category).State = EntityState.Modified; // Kategori verisini güncelle
        //        appDbContext.SaveChanges(); // Değişiklikleri veritabanına kaydet
        //        return RedirectToAction("Index", "Home"); // Başarılı olduğunda ana sayfaya yönlendir
        //    }

        //    return View(category); // Eğer model geçerli değilse tekrar düzenleme sayfasını yükle
        //}


        //[HttpPost]
        //public JsonResult Edit(int id)
        //{
        //    if (id == 0)
        //    {
        //        return Json(new
        //        {
        //            status = 400
        //        });
        //    }
        //    var oldcategory = appDbContext.Categories.FirstOrDefault(x => x.Id == id);
        //    if (oldcategory != null)
        //    {
        //        appDbContext.Categories.Update(oldcategory);
        //        appDbContext.SaveChanges();
        //    }
        //    return Json(new
        //    {
        //        status = 200
        //    });
        //}

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
                appDbContext.Categories.Remove(model);
                appDbContext.SaveChanges();
            }
            return Json(new
            {
                status = 200
            });
        }

    }
}
