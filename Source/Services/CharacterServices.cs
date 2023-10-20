using Application.ViewModels;
using Newtonsoft.Json.Linq;
using Repository.Data;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class CharacterServices
    {
        public async Task<List<CharacterViewModel>> getAllCharacters()
        {
            CharacterRepository repository = new();
            List<Character> data = await repository.getAll();
            List<CharacterViewModel> characters = new();

            foreach (var item in data)
            {
                JObject origin = JObject.Parse(item.origin.ToString());
                JObject location = JObject.Parse(item.location.ToString());
                CharacterViewModel character = new();
                character.id = item.id;
                character.name = item.name;
                character.status = item.status;
                character.image = item.image;
                character.gender = item.gender;
                character.species = item.species;
                character.type = item.type;
                character.origin = origin["name"].ToString();
                character.location = location["name"].ToString();
                character.created = item.created;
                characters.Add(character);
            }
            return characters;
        }
    }
}
