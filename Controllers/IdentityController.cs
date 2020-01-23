using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PcRepaire.Models;

namespace PcRepaire.Controllers
{
    public class IdentityController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        //private readonly ILogger<IdentityController> _logger;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login ([Bind("Name", "Password", "RememberMe")] User user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Name, user.Password, user.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                    return Content("succeed");
                else
                    return Content("Not succeed");
            }
            else
                return Content("model error");
        }

       
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }

    }
}