using Microsoft.AspNetCore.Mvc;

namespace RickyAndMorthyApp.Controllers
{
    public class CharacterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
