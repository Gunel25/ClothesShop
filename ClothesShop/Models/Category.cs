using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ClothesShop.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ValidateNever]
        public List<Products> Products { get; set; }
      //  public bool IsStock { get; set; } = true;
    }
}
