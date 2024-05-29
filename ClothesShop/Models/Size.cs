using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ClothesShop.Models
{
    public class Size
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<SizeToProduct> SizeToProducts { get; set; }
      
    }
}
