using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Stripe.Climate;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothesShop.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }
        [ValidateNever]
        public string ImgUrlBase { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        public int StockQuantity { get; set; }
        [ValidateNever]
        public bool IsStock { get; set; } = true;
        [ValidateNever]
        public List<OrderItem> OrderItems { get; set; }
        [ValidateNever]
        public List<SizeToProduct> SizeToProducts { get; set; }
        [ValidateNever]
        public List<ColorToProduct> ColorToProducts { get; set; }
        [ValidateNever]
        public List<Images> Images { get; set; }
        [NotMapped]
        [Required]
        public IFormFile ImgUrlBaseFile { get; set; }
        [NotMapped]
        [ValidateNever]
        public List<IFormFile> ImagesFiles { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Please select at least one color.")]
        public List<int> ColorsId { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Please select at least one size.")]
        public List<int> SizesId { get; set; }
    }
}
