using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Repository.Data;
using Repository.Models;
using System.Xml.Linq;

namespace RickyAndMorthyApp.Controllers
{
    public class CharacterController : Controller
    {
        List<CharacterViewModel>? characterList;
        public async Task<IActionResult> Index(string search)
        {
            CharacterServices character = new();
            characterList = new();

            if(!string.IsNullOrEmpty(search))
            {
                characterList = await character.filterCharacters($"name={search}");
                //name=rick&status=alive
            } else
            {
                await character.getInfo();
                characterList = await character.getAllCharacters(character.pages);
            }
           
            return View(characterList);
        }
    }
}
