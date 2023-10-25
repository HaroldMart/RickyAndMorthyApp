using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace RickyAndMorthyApp.Controllers
{
    public class HomeController : Controller
    {
        List<CharacterViewModel>? characterList;
        private static readonly Random random = new();
        List<int>? charactersIdList;

        public async Task<IActionResult> Index()
        {
            charactersIdList = new();
            for (int id = 1; id <= 6; id++)
            {
                charactersIdList.Add(random.Next(21, 60));
            }

            CharacterServices character = new();
            LocationServices location = new();
            EpisodeServices episode = new();

            await character.getInfo();
            await location.getInfo();
            await episode.getInfo();

            ViewBag.pagesCharacter = character.pages;
            ViewBag.countCharacter = character.count;

            ViewBag.pagesLocation = location.pages;
            ViewBag.countLocation = location.count;

            ViewBag.pagesEpisode = episode.pages;
            ViewBag.countEpisode = episode.count;

            characterList = new();
            characterList = await character.getMultipleCharacters(charactersIdList.ToArray());
            

            return View(characterList);
        }
    }
}