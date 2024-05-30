using ClothesShop.DAL;
using ClothesShop.ViewModels;
using ClothesShop.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext appDbContext;
        public ShopController(AppDbContext _appDbContext)
        {
            appDbContext = _appDbContext;
        }
        public IActionResult shop5()
        {
            ShopVM model = new ShopVM
            {
                categories = appDbContext.Categories.Where(x => x.IsActive == true).ToList(),
                products = appDbContext.Products.Where(x => x.IsStock == true).ToList(),
                Sizes = appDbContext.Sizes.ToList(),
                Colors = appDbContext.Colors.ToList(),
            };
            return View(model);
        }

        public IActionResult product2_detail(int id)
        {
            var product = appDbContext.Products
                .Include(x => x.Images)
                .Include(x => x.ColorToProducts).ThenInclude(y => y.Color)
                .Include(x => x.SizeToProducts).ThenInclude(y => y.Size)
                .FirstOrDefault(x => x.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            var colors = appDbContext.Colors.ToList();
            var sizes = appDbContext.Sizes.ToList();

            ManyModels model = new ManyModels
            {
                Products = product,
                Colors = colors,
                Sizes = sizes
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToCartt(int productId, int selectedColorId, int selectedSizeId, int quantity)
        {
            var product = appDbContext.Products
                .Include(p => p.ColorToProducts)
                    .ThenInclude(pc => pc.Color)
                .Include(p => p.SizeToProducts)
                    .ThenInclude(ps => ps.Size)
                .FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                return NotFound();
            }

            var selectedColor = product.ColorToProducts.FirstOrDefault(pc => pc.ColorId == selectedColorId)?.Color;
            var selectedSize = product.SizeToProducts.FirstOrDefault(ps => ps.SizeId == selectedSizeId)?.Size;

            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartItem cartItem = cart.FirstOrDefault(c => c.ProductId == productId && c.Color == selectedColor.Name && c.Size == selectedSize.Name);
            if (cartItem != null)
            {
                cartItem.Quantity += quantity;
            }
            else
            {
                cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    ProductName = product.Title,
                    Price = product.Price,
                    Quantity = quantity,
                    ImgUrlBase = product.ImgUrlBase,
                    Color = selectedColor?.Name ?? "Unknown",
                    Size = selectedSize?.Name ?? "Unknown"
                });
            }

            HttpContext.Session.SetJson("Cart", cart);

            // Calculate total prices
            decimal grandTotal = cart.Sum(item => item.Total);
            decimal subTotal = cart.Sum(item => item.Quantity * item.Price);
            decimal Total = cart.Sum(item => item.Quantity * item.Price);

            return RedirectToAction("shop5", "Shop");
        }

        public IActionResult shop_cart()
        {
          var cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();

            CartVM cartVM = new CartVM()
            {
                CartItems = cart,
                GrandTotal = cart.Sum(x=>x.Quantity*x.Price),
            };
            var shopvm =new ShopVM 
            { CartVM = cartVM };
            return View(shopvm);
        }
    }
}
