using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PcRepaire.Models;
using PcRepaire.Models.ViewModels;
using System.Diagnostics;
using System.Linq;
using PcRepaire.Models.ViewModels;
using PcRepaire.Data;
using Microsoft.EntityFrameworkCore;

namespace PcRepaire.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
