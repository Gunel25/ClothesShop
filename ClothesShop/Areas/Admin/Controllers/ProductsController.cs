using ClothesShop.DAL;
using ClothesShop.Extensions;
using ClothesShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace ClothesShop.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly IWebHostEnvironment _env;
        public ProductsController( AppDbContext _appDbContext, IWebHostEnvironment env)
        {
            appDbContext = _appDbContext;
            _env = env;
        }
        public IActionResult Index()
        {
            return View(appDbContext.Products.Include(x => x.Category).Where(x=>x.IsStock==true).ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Category = appDbContext.Categories.Where(x => x.IsActive).ToList();
            ViewBag.Color = appDbContext.Colors.ToList();
           ViewBag.Size = appDbContext.Sizes.ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Products model)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.Category = appDbContext.Categories.Where(x=>x.IsActive).ToList();
                ViewBag.Color = appDbContext.Colors.ToList();
                ViewBag.Size = appDbContext.Sizes.ToList();
                return View(model);
            }
            //Tek şeklin bazaya ve papkaya yüklenmesi
            if (!model.ImgUrlBaseFile.IsImage())
            {
                ModelState.AddModelError("Photo", "Image type is not valid");
                return View(model);
            }
            string filename = await model.ImgUrlBaseFile.SaveFileAsync(_env.WebRootPath, "uploadProducts");
            model.ImgUrlBase = filename;

            appDbContext.Products.Add(model);
            appDbContext.SaveChanges();

            if (model.ImagesFiles != null)
            {
                foreach (var item in model.ImagesFiles)
                {
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Image type is not valid");
                        return View(model);
                    }
                    string filename2 = await item.SaveFileAsync(_env.WebRootPath, "uploadProducts");
                    Images images = new Images
                    {
                        ProductId = model.Id,
                        ImgUrl = filename2,
                    };

                    appDbContext.Images.Add(images);
                    appDbContext.SaveChanges();
                }
            }
            if (model.ColorsId != null)
            {
                foreach (var item in model.ColorsId)
                {
                    ColorToProduct colorToProductModel = new ColorToProduct
                    {
                        ProductId = model.Id,
                        ColorId = item,
                    };

                    appDbContext.ColorToProducts.Add(colorToProductModel);
                    appDbContext.SaveChanges();

                }
            }
            if (model.SizesId != null)
            {
                foreach (var item in model.SizesId)
                {
                    SizeToProduct sizeToProductModel = new SizeToProduct
                    {
                        ProductId = model.Id,
                        SizeId = item,
                    };

                    appDbContext.SizeToProducts.Add(sizeToProductModel);
                    appDbContext.SaveChanges();

                }
            }
            return RedirectToAction("Index");
        }
  
  
        public IActionResult Edit(int id)
        {
            ViewBag.Category = appDbContext.Categories.Where(x => x.IsActive).ToList();
            ViewBag.Color = appDbContext.Colors.ToList();
            ViewBag.Size = appDbContext.Sizes.ToList();

            var model = appDbContext.Products.Include(x => x.ColorToProducts).Include(x => x.SizeToProducts).Include(x => x.Images).FirstOrDefault(x=>x.Id == id);
            var dbColors = appDbContext.ColorToProducts.Where(x => x.ProductId == id).ToList();
            var dbSizes = appDbContext.SizeToProducts.Where(x => x.ProductId == id).ToList();

            model.ColorsId = new List<int>();
            model.SizesId = new List<int>();
            foreach (var item in dbColors)
            {
                model.ColorsId.Add(item.ColorId);
            }
            foreach (var item in dbSizes)
            {
                model.SizesId.Add(item.SizeId);
            }
            return View(model);
        }

        ////[HttpPost]
        ////public async Task<IActionResult> Edit(Products productModel)
        ////{
        ////    ViewBag.Category = appDbContext.Categories.ToList();
        ////    ViewBag.Color = appDbContext.Colors.ToList();
        ////    var modelDb = appDbContext.Products.FirstOrDefault(x => x.Id == productModel.Id);
        ////    modelDb.Title= productModel.Title;
        ////    modelDb.Description= productModel.Description;
        ////    modelDb.Price= productModel.Price;
        ////    modelDb.CategoryId= productModel.CategoryId;
        ////    appDbContext.SaveChanges();

        ////    if (modelDb == null)
        ////    {
        ////        return RedirectToAction("Index");
        ////    }
        ////    //if (!ModelState.IsValid)
        ////    //{
        ////    //    return View(productModel);
        ////    //}
        ////    ////if(modelDb.Title ==null || modelDb.Description==null || modelDb.Price==null  )
        ////    ////{
        ////    ////    return View(productModel);
        ////    ////}

        ////    if (modelDb.Title == null)
        ////    {
        ////        return RedirectToAction("Edit");
        ////    }
        ////    if (modelDb.Description == null)
        ////    {
        ////        return RedirectToAction("Edit");
        ////    }
        ////    if (modelDb.Price == null)
        ////    {
        ////        return RedirectToAction("Edit");
        ////    }
        ////    //Tek şekil
        ////    if (productModel.ImgUrlBaseFile!=null)
        ////    {
        ////        if (!productModel.ImgUrlBaseFile.IsImage())
        ////        {
        ////            ModelState.AddModelError("Photo", "Image type is not valid");
        ////            return View(productModel);
        ////        }
        ////        string filename = await productModel.ImgUrlBaseFile.SaveFileAsync(_env.WebRootPath, "uploadProducts");
        ////        modelDb.ImgUrlBase = filename;
        ////        appDbContext.SaveChanges();
        ////    }

        ////    if(productModel.ImagesFiles!=null)
        ////    {
        ////        foreach (var item in productModel.ImagesFiles)
        ////        {
        ////            if (!item.IsImage())
        ////            {
        ////                ModelState.AddModelError("Photo", "Image type is not valid");
        ////                return View(productModel);
        ////            }
        ////            string filename2 = await item.SaveFileAsync(_env.WebRootPath, "uploadProducts");

        ////            Images images = new Images
        ////            {
        ////                ProductId = productModel.Id,
        ////                ImgUrl = filename2,
        ////            };

        ////            appDbContext.Images.Add(images);
        ////            appDbContext.SaveChanges();

        ////        }
        ////    }

        ////    var colorsDb = appDbContext.ColorToProducts.Where(x => x.ProductId == productModel.Id);


        ////        appDbContext.ColorToProducts.RemoveRange(colorsDb);
        ////        appDbContext.SaveChangesAsync();



        ////        foreach (var item in productModel.ColorsId)
        ////    {
        ////        ColorToProduct colorToProductModel = new ColorToProduct
        ////        {
        ////            ProductId = productModel.Id,
        ////            ColorId = item,
        ////        };

        ////        appDbContext.ColorToProducts.Add(colorToProductModel);
        ////        appDbContext.SaveChanges();
        ////    }

        ////    return RedirectToAction("Index");
        ////}

        [HttpPost]
        public async Task<IActionResult> Edit(Products productModel)
        {
            ViewBag.Category = appDbContext.Categories.Where(x => x.IsActive).ToList();
            ViewBag.Color = appDbContext.Colors.ToList();
            ViewBag.Size = appDbContext.Sizes.ToList();
            var modelDb = await appDbContext.Products.FirstOrDefaultAsync(x => x.Id == productModel.Id);

            if (modelDb == null)
            {
                return RedirectToAction("Index");
            }

            modelDb.Title = productModel.Title;
            modelDb.Description = productModel.Description;
            modelDb.Price = productModel.Price;
            modelDb.CategoryId = productModel.CategoryId;

            if (productModel.ImgUrlBaseFile != null)
            {
                if (!productModel.ImgUrlBaseFile.IsImage())
                {
                    ModelState.AddModelError("Photo", "Image type is not valid");
                    return View(productModel);
                }
                string filename = await productModel.ImgUrlBaseFile.SaveFileAsync(_env.WebRootPath, "uploadProducts");
                modelDb.ImgUrlBase = filename;
            }

            if (productModel.ImagesFiles != null)
            {
                foreach (var item in productModel.ImagesFiles)
                {
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Image type is not valid");
                        return View(productModel);
                    }
                    string filename2 = await item.SaveFileAsync(_env.WebRootPath, "uploadProducts");

                    Images images = new Images
                    {
                        ProductId = productModel.Id,
                        ImgUrl = filename2,
                    };

                    appDbContext.Images.Add(images);
                }
            }

            var colorsDb = appDbContext.ColorToProducts.Where(x => x.ProductId == productModel.Id);
            appDbContext.ColorToProducts.RemoveRange(colorsDb);

            if (productModel.ColorsId != null)
            {
                foreach (var item in productModel.ColorsId)
                {
                    ColorToProduct colorToProductModel = new ColorToProduct
                    {
                        ProductId = productModel.Id,
                        ColorId = item,
                    };

                    appDbContext.ColorToProducts.Add(colorToProductModel);
                }
            }

            var sizesDb = appDbContext.SizeToProducts.Where(x => x.ProductId == productModel.Id);
            appDbContext.SizeToProducts.RemoveRange(sizesDb);

            if (productModel.SizesId != null)
            {
                foreach (var item in productModel.SizesId)
                {
                    SizeToProduct sizeToProductModel = new SizeToProduct
                    {
                        ProductId = productModel.Id,
                        SizeId = item,
                    };

                    appDbContext.SizeToProducts.Add(sizeToProductModel);
                }
            }
            await appDbContext.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        public JsonResult DeleteImage(int id)
        {
            if(id!=0)
            {
               var model = appDbContext.Images.Find(id);
                appDbContext.Images.Remove(model);
                appDbContext.SaveChanges();
            }
            return Json(new
            {
                status = 200
            });
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
                //appDbContext.Products.Remove(model);
                model.IsStock = false;
                appDbContext.SaveChanges();
            }
            return Json(new
            {
                status = 200
            });
        }

    }


}
