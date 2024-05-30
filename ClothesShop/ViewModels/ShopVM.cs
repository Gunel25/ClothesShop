using ClothesShop.Models;
//using System.Drawing;

namespace ClothesShop.ViewModels
{
    public class ShopVM
    {
        public List<Category> categories {  get; set; }
        public List<Products> products { get; set; }
        public List<Color> Colors { get; set; }
        public List<Size> Sizes { get; set; }
        public List<int> SelectedColors { get; set; }
        public List<int> SelectedSizes { get; set; }
        public CartVM CartVM { get; set; }
        public Order Orders { get; set; }


    }
}
