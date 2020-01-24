using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PcRepaire.Models;
using System.Threading.Tasks;

namespace PcRepaire.Controllers
{
    public class IdentityController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<IdentityController> _logger;
        //private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityController(SignInManager<IdentityUser> signInManager, ILogger<IdentityController> logger)
        {
            _logger = logger;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login([Bind("Name", "Password", "RememberMe")] User user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(user.Name, user.Password, user.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    _logger.LogInformation(user.Name + " was connected");
                    return RedirectToRoute(new { Controller = "Home", Action = "Index" });
                }
                else
                {
                    _logger.LogInformation(user.Name + " try connected");
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View(user);
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid attempt.");
                return View(user);
            }
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToRoute(new { Controller = "Home", Action = "Index" });
        }

    }
}