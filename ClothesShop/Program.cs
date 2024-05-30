using ClothesShop.DAL;
using ClothesShop.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using ClothesShop.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddIdentity<ProgramUser, IdentityRole<int>>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true; //Rəqəm tələb edin
    options.Password.RequireLowercase = false; //Kiçik hərf tələb edin
    options.Password.RequireUppercase = true; //Böyük hərf tələb edin
    options.Password.RequiredLength = 6; //Tələb olunan uzunluq...
    options.Password.RequireNonAlphanumeric = false; //@ * ! ve.s kimi simvollar olmalidi
    options.Lockout.MaxFailedAccessAttempts = 5; //5 girişten sonra bloklanir 
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMilliseconds(5); //bloklamndiqdan 5deq sonra acilir
    options.Lockout.AllowedForNewUsers = true; //yeni qeydiyyat userdirse passwordu unuda biler.bir nece yazdiqda bloklamaya bilersiz
   //   options.User.AllowedUserNameCharacters =
   //"abcdefghijklmnopqrstuvwxyz0123456789._";//olmasını istediyiniz vacib karaterleri yazin
    options.User.RequireUniqueEmail = true; //unique emaail adresleri olsun (1emaille bir qeydiyyat)
    options.SignIn.RequireConfirmedEmail = false; //qeydiyyat etdikden sonra email ile token gönderecek 
    options.SignIn.RequireConfirmedPhoneNumber = false; //telefon doğrulaması
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Account/AccessDenied";
});
builder.Services.AddScoped<IEmailService,EmailService>();

var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole<int>>>();
    var userManager = services.GetRequiredService<UserManager<ProgramUser>>();
    await SeedDataAsync(roleManager, userManager);
}
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//builder.Services.AddSession(options =>
//{
//    options.IdleTimeout = TimeSpan.FromMinutes(30); // Oturumun ne kadar süre aktif kalaca??n? belirleyin
//    options.Cookie.HttpOnly = true; // XSS korumas? için
//    options.Cookie.IsEssential = true; // Oturum çerezlerinin temel oldu?undan emin olun
//}); 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=DashBoard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
async Task SeedDataAsync(RoleManager<IdentityRole<int>> roleManager, UserManager<ProgramUser> userManager)
{
    if (!await roleManager.RoleExistsAsync("Admin"))
    {
        await roleManager.CreateAsync(new IdentityRole<int>("Admin"));
    }
    if (!await roleManager.RoleExistsAsync("User"))
    {
        await roleManager.CreateAsync(new IdentityRole<int>("User"));
    }

    var adminEmail = "cabbarligunel0899@gmail.com";
    var adminUser = await userManager.FindByEmailAsync(adminEmail);
    if (adminUser == null)
    {
        var programUser = new ProgramUser
        {
            Email = adminEmail,
            UserName = "cabbarligunel0899@gmail.com",
            Name = "cabbarligunel0899@gmail.com",
        };
        var result = await userManager.CreateAsync(programUser, "Gunel123!");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(programUser, "Admin");
        }
        else
        {
            // Kullan?c? zaten mevcutsa, rolünü kontrol et ve ekle
            if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
            {
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }
    }
}
