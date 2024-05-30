using Stripe;
using ClothesShop.Models;
namespace ClothesShop.ViewModels
{
    public class CartItem
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string ImageUrl { get; set; }
        public string ImgUrlBase { get; set; }
        public decimal Total
        {
            get { return Quantity * Price; }
        }

        public CartItem()
        {
        }

        public CartItem(Products product)
        {
            ProductId = product.Id;
            ProductName = product.Title;
            Price = product.Price;
            ImageUrl = product.Images[0].ImgUrl;
            ImgUrlBase = product.ImgUrlBase;
        }
    }
}
