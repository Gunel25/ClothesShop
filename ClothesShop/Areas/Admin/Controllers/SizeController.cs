using ClothesShop.DAL;
using ClothesShop.Migrations;
using ClothesShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SizeController : Controller
    {
        private readonly AppDbContext appDbContext;
        public SizeController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        //public IActionResult Index()
        //{
        //    return View(appDbContext.Sizes.ToList());
        //}

        //[HttpPost]
        //public IActionResult Create(Size model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        // return Json(new
        //        {
        //            status = 400
        //        });        //    }

        //    appDbContext.Sizes.Add(model);
        //    appDbContext.SaveChanges();
        //return Json(new
        //    {
        //        status = 200
        //    });        //}

        //[HttpGet]
        //public JsonResult Edit(int id)
        //{
        //    var size = appDbContext.Sizes.Find(id); // Kategori verilerini veritabanından al
        //    if (size == null)
        //    {
        //        return Json(new { status = 400 });
        //    }
        //    return Json(size); // Kategori verilerini JSON formatında dön
        //}

        //[HttpPost]
        //public IActionResult Edit(Size model)
        //{
        //    // // ViewBag.Category = appDbContext.Categories.ToList();
        //    if (!ModelState.IsValid)
        //    {
        // return Json(new
        //        {
        //            status = 400
        //        });        //         //    }
        //    appDbContext.Sizes.Update(model);
        //    appDbContext.SaveChanges();
        //return Json(new
        //    {
        //        status = 200
        //    });        //}        //}

        //public JsonResult Delete(int id)
        //{
        //    if (id == 0)
        //    {
        //        return Json(new
        //        {
        //            status = 400
        //        });
        //    }
        //    var model = appDbContext.Sizes.Find(id);
        //    if (model != null)
        //    {
        //       // model.IsActive = false;
        //         appDbContext.Sizes.Remove(model);
        //        appDbContext.SaveChanges();
        //    }
        //    return Json(new
        //    {
        //        status = 200
        //    });
        //}

        public IActionResult GetSize()
        {
            return View();
        }
        public JsonResult SizeList()
        {
            return Json(appDbContext.Sizes.ToList());
        }
        [HttpPost]
        public JsonResult Add(Size size)
        {
            appDbContext.Sizes.Add(size);
            appDbContext.SaveChanges();
            return Json("Added.");
        }
        [HttpGet]
        public JsonResult Edit(int id)
        {
            var size = appDbContext.Sizes.FirstOrDefault(s => s.Id == id);
            return Json(size);
        }
        [HttpPost]
        public JsonResult Update(Size size)
        {
            appDbContext.Sizes.Update(size);
            appDbContext.SaveChanges();
            return Json("Succesfully.");
        }
        [HttpPost]
        public JsonResult Delete(int id)
        {
            var size = appDbContext.Sizes.FirstOrDefault(s => s.Id == id);
            if (size != null)
            {
                appDbContext.Sizes.Remove(size);
                appDbContext.SaveChanges();
                return Json("Succesfully.");
            }
            return Json("Not Found.");

        }
    }
}
