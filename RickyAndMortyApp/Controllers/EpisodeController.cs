using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

namespace RickyAndMorthyApp.Controllers
{
    public class EpisodeController : Controller
    {
        List<EpisodeViewModel>? episodeList;
        public async Task<IActionResult> Index(string search)
        {
            EpisodeServices episode = new();
            episodeList = new();

            if (!string.IsNullOrEmpty(search))
            {
                episodeList = await episode.filterEpisodes($"name={search}");
            }
            else
            {
                await episode.getInfo();
                episodeList = await episode.getAllEpisodes(episode.pages);
            }

            return View(episodeList);
        }
    }
}
