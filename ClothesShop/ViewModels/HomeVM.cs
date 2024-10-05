using ClothesShop.Models;

namespace ClothesShop.ViewModels
{
    public class HomeVM
    {
        public List<Category> Categories { get; set; }
        public List<Products> Products { get; set; }
        public List<Slider> Sliders { get; set; }
    }
}
