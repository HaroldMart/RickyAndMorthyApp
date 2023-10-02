using Microsoft.AspNetCore.Mvc;

namespace RickyAndMorthyApp.Controllers
{
    public class LocationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
