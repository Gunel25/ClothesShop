using ClothesShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.DAL
{
    public class AppDbContext: IdentityDbContext<ProgramUser, IdentityRole<int>, int>         //IdentityDbContext<ProgramUser>
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ProgramUser> Users { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ColorToProduct> ColorToProducts { get; set; }
        public DbSet<SizeToProduct> SizeToProducts { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<Images> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Slider>().HasData(
               new Slider 
               {
                   Id=1, 
                   Title= "Oversize Bisiklet Yaka Pamuk Baskılı Kısa Kollu Tişört", 
                   Description= "Ürünümüz unisex olduğundan kadın ve erkek için uygundur.", 
                   ImgUrl = "slideshow-character1.png", 
                   IsCheck=true 
               },

               new Slider 
               {
                   Id=2, 
                   Title= "Kadın Dik Yaka Uzun Kollu Bluz", 
                   Description= "Modelin Ölçüleri: Boy: 1.70, Göğüs: 87, Bel: 65, Kalça: 93, Beden:S/34/1 Stüdyo çekimlerinde renkler ışık farklılığından dolayı değişiklik gösterebilir.\r\n", 
                   ImgUrl= "slideshow-character2.png", 
                   IsCheck = true }
               );
        }

    }
}
