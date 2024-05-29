using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ClothesShop.Models
{
    public class Color
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ColorToProduct> ColorToProducts { get; set; }
    }
}
