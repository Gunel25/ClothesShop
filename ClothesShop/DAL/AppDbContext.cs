using ClothesShop.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClothesShop.DAL
{
    public class AppDbContext: IdentityDbContext<ProgramUser>
    {
        public AppDbContext(DbContextOptions options):base(options) { }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Slider>().HasData(
               new Slider {Id=1, Title= "Oversize Bisiklet Yaka Pamuk Baskılı Kısa Kollu Tişört", Description= "Ürünümüz unisex olduğundan kadın ve erkek için uygundur.", ImgUrl = "cart-item-2.jpg", IsCheck=true },
               new Slider {Id=2, Title= "Kadın Dik Yaka Uzun Kollu Bluz", Description= "Modelin Ölçüleri: Boy: 1.70, Göğüs: 87, Bel: 65, Kalça: 93, Beden:S/34/1 Stüdyo çekimlerinde renkler ışık farklılığından dolayı değişiklik gösterebilir.\r\n", ImgUrl= "cart-item-1.jpg", IsCheck = true }
               );
        }

    }
}
