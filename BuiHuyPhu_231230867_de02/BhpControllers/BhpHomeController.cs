using System.Diagnostics;
using BuiHuyPhu_231230867_de02.Models;
using Microsoft.AspNetCore.Mvc;

namespace BuiHuyPhu_231230867_de02.Controllers
{
    public class BhpHomeController : Controller
    {
        private readonly ILogger<BhpHomeController> _logger;

        public BhpHomeController(ILogger<BhpHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult BhpIndex()
        {
            return View();
        }
        public IActionResult bhpAbout()
        {
            return View();
        }

        public IActionResult BhpPrivacy()
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
