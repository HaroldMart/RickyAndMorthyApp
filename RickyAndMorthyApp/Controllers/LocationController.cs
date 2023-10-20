using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;

namespace RickyAndMorthyApp.Controllers
{
    public class LocationController : Controller
    {
        public async Task<IActionResult> Index()
        {
            LocationRepository location = new LocationRepository();
            List<Location> locations = await location.getAll();

            return View(locations);
        }
    }
}
