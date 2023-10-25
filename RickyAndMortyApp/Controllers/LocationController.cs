using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;

namespace RickyAndMorthyApp.Controllers
{
    public class LocationController : Controller
    {
        List<LocationViewModel>? locationList;
        public async Task<IActionResult> Index(string search)
        {
            LocationServices location = new();
            locationList = new();

            if (!string.IsNullOrEmpty(search))
            {
                locationList = await location.filterLocations($"name={search}");
            }
            else
            {
                await location.getInfo();
                locationList = await location.getAllLocations(location.pages);
            }

            return View(locationList);
        }
    }
}
