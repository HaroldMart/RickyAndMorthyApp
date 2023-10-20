using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;

namespace RickyAndMorthyApp.Controllers
{
    public class CharacterController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            CharacterServices character = new();
            //Character info = await character.getCharacter();
            List<CharacterViewModel> characterList = await character.getAllCharacters();

            //await character.filterCharacters("name=rick&status=alive");

            return View(characterList);
        }
    }
}
