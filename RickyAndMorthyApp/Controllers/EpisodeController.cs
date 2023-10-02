using Microsoft.AspNetCore.Mvc;

namespace RickyAndMorthyApp.Controllers
{
    public class EpisodeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
