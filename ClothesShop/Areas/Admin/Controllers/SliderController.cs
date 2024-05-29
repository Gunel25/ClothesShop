using ClothesShop.Controllers;
using ClothesShop.DAL;
using ClothesShop.Extensions;
using ClothesShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Areas.Admin.Controllers
{
    [Area("Admin")]
   // [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext _appDbContext, IWebHostEnvironment env)
        {
            appDbContext = _appDbContext;
            _env = env;
        }

        public IActionResult Index()
        {
            return View(appDbContext.Sliders.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
            {
                return View(slider);
            }
            if (!slider.ImgFile.IsImage())
            {
                ModelState.AddModelError("Photo", "Image type is not valid");
                return View(slider);
            }
            string filename = await slider.ImgFile.SaveFileAsync(_env.WebRootPath, "uploadSlider");
            slider.ImgUrl = filename;

            appDbContext.Sliders.Add(slider);
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

            var slider = appDbContext.Sliders.Find(id);
            if (slider != null)
            {
                appDbContext.Sliders.Remove(slider);
                appDbContext.SaveChanges();
            }
            return Json(new
            {
                status = 200
            });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var model = appDbContext.Sliders.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return RedirectToAction("Index");

            }
            return View(model);

        }

        //[HttpPost]
        //public IActionResult Edit(Slider slider)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(slider);
        //    }
        //    appDbContext.Sliders.Update(slider);
        //    appDbContext.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public async Task<IActionResult> EditAsync(Slider slider)
        {
            var oldSlider = appDbContext.Sliders.Find(slider.Id);
            //if (!ModelState.IsValid)
            //{
            //    return View(slider);
            //}
            if (slider.ImgFile != null)
            {

                if (!slider.ImgFile.IsImage())
                {
                    ModelState.AddModelError("Photo", "Image type is not valid");
                    return View(slider);
                }
                string filename = await slider.ImgFile.SaveFileAsync(_env.WebRootPath, "UploadSlider");

                oldSlider.ImgUrl = filename;
            }
            oldSlider.Title = slider.Title;
            oldSlider.Description = slider.Description;
            oldSlider.IsCheck = slider.IsCheck;

            appDbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
