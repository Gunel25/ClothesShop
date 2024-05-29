using ClothesShop.DAL;
using ClothesShop.Models;
using ClothesShop.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ClothesShop.Extensions;
using System.Net;

namespace ClothesShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext appDbContext;
        private readonly UserManager<ProgramUser> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly SignInManager<ProgramUser> _signInManager;
        private readonly IEmailService _emailService;
        public AccountController(AppDbContext _appDbContext, UserManager<ProgramUser> userManager, RoleManager<IdentityRole<int>> roleManager, SignInManager<ProgramUser> signInManager, IEmailService emailService)
        {
            appDbContext = _appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _emailService = emailService;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            ProgramUser programUser = new ProgramUser
            {
                Email = model.Email,
                UserName = model.Email
            };

            var result = await _userManager.CreateAsync(programUser, model.Password);
            if (result.Succeeded)
            {
                
                var token = await _userManager.GenerateEmailConfirmationTokenAsync(programUser);
                // var confirmationLink = Url.Action("Index", "Home", new { userId = programUser.Id, token = token }, Request.Scheme);
                var confirmationLink = Url.Content($"~/Home/Index?userId={programUser.Id}&token={WebUtility.UrlEncode(token)}");

                await _emailService.SendEmailAsync(model.Email, "Confirm your email", $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");
                await _userManager.AddToRoleAsync(programUser, "User");
                await _signInManager.SignInAsync(programUser, true);


                return RedirectToAction("Index", "Home");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("", item.Description);
            }
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Something incorrect");

            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.IsRemember, false);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Pssword or Email incorrect");
                }
            }

            return RedirectToAction("Index", "Home");

        }


        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }

        //public async Task SeedRoles()
        //{
        //    if(!await _roleManager.RoleExistsAsync(roleName: "Admin"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole<int>(roleName: "Admin"));
        //    }

        //    if (!await _roleManager.RoleExistsAsync(roleName: "User"))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole<int>(roleName: "User"));
        //    }
        //}

        //public async Task SeedAdmin()
        //{
        //    if (_userManager.FindByEmailAsync("cabbarligunel0899@gmail.com").Result == null)
        //    {
        //        ProgramUser programUser = new ProgramUser
        //        {
        //            Email = "cabbarligunel0899@gmail.com",
        //            UserName = "cabbarligunel0899@gmail.com"
        //        };
        //        var result = await _userManager.CreateAsync(programUser, "gunel0899C!");
        //        if (result.Succeeded)
        //        {
        //            await _userManager.AddToRoleAsync(programUser, "Admin");
        //            await _signInManager.SignInAsync(programUser, true);

        //            RedirectToAction("Index", "Home");
        //        }
        //    }
        //}
    }
}
