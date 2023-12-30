using Microsoft.AspNetCore.Mvc;
using SekawanMedia.Models;
using System.Diagnostics;

namespace SekawanMedia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
			return View();
			//if (HttpContext.Session.GetString("IsLogged") != null)
   //         {

			//	return View();
			//}
   //         else { return RedirectToAction("Index", "Login"); }
        }

        public IActionResult Privacy()
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
