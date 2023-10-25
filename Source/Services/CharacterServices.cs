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
        public int count = 0;
        public int pages = 0;
        private CharacterRepository repository;

        public CharacterServices()
        {
            repository = new();
        }

        public async Task getInfo()
        {
            int[] info = await repository.getInfo();
            count = info[0];
            pages = info[1];
        }

        public async Task<List<CharacterViewModel>> getAllCharacters(int pages)
        {
            CharacterRepository repository = new();
            

            List<Character> data = await repository.getAll(pages);
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
                characters.Add(character);
            }
            return characters;
        }

        public async Task<List<CharacterViewModel>> getMultipleCharacters(int[] list)
        {
            CharacterRepository repository = new();
            List<Character> data = await repository.getMultiple(list);
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
                characters.Add(character);
            }
            return characters;
        }

        public async Task<List<CharacterViewModel>> filterCharacters(string search)
        {
            CharacterRepository repository = new();
            List<Character> data = await repository.filter(search);
            List<CharacterViewModel> searchCharacters = new();

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
                searchCharacters.Add(character);
            }
            return searchCharacters;
        }
    }
}
