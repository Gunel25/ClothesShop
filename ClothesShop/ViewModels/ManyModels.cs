using ClothesShop.Models;

namespace ClothesShop.ViewModels
{
    public class ManyModels
    {
        public Products Products { get; set; }
        public List<Color> Colors { get; set; }
        public List<Size> Sizes { get; set; }

        public List<int> SelectedColors { get; set; }
        public List<int> SelectedSizes { get; set; }

    }
}
