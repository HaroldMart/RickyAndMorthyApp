using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace Repository.Data
{
    public class CharacterRepository
    {
        public async Task<List<Character>> getAll()
        {
            List<Character> characters = new List<Character>();

            try
            {
                HttpClient client = Connection.Instance._httpClient;

                Uri url = new(client.BaseAddress, "character");

                HttpResponseMessage response = await client.GetAsync(url);

                var data = await response.Content.ReadFromJsonAsync<Info>();

                if (data != null)
                {
                    foreach (var item in data.results)
                    {
                        Character character = new Character();
                        JObject json = JObject.Parse(item.ToString());

                        character.id = int.Parse(json["id"].ToString());
                        character.name = json["name"].ToString();
                        character.status = json["status"].ToString();
                        character.species = json["species"].ToString();
                        character.gender = json["gender"].ToString();
                        character.type = json["type"].ToString();
                        character.origin = json["origin"];
                        character.location = json["location"];
                        character.image = json["image"].ToString();
                        character.episode = JsonSerializer.Deserialize<string[]>(json["episode"].ToString());
                        character.url = json["url"].ToString();
                        character.created = json["created"].ToString();

                        characters.Add(character);
                    }
                }

                return characters;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return characters;
        }

        #region "get"
        //public async Task<Character> get(string idCharacter) {
        //    try
        //    {
        //        HttpClient client = Connection.Instance._httpClient;

        //        Uri url = new(client.BaseAddress, $"character/{idCharacter}");

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        var data = await response.Content.ReadFromJsonAsync<Character>();

        //        Character character = data;

        //        Console.WriteLine(data.name);

        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return new Character { };
        //}
        #endregion

        #region "getMultiple"

        //public async Task<List<Character>> getMultiple(string[] list)
        //{
        //    List<Character> characters = new List<Character>();

        //    string multipleCharacters = "";
        //    foreach (string item in list)
        //    {
        //        multipleCharacters += $"{item},";
        //    }

        //    try
        //    {
        //        HttpClient client = Connection.Instance._httpClient;

        //        Uri url = new(client.BaseAddress, $"character/{multipleCharacters}");

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        var data = await response.Content.ReadFromJsonAsync<List<object>>();

        //        if (data != null)
        //        {
        //            foreach (var item in data)
        //            {
        //                Character character = new Character();
        //                JObject json = JObject.Parse(item.ToString());

        //                character.id = int.Parse(json["id"].ToString());
        //                character.name = json["name"].ToString();
        //                character.status = json["status"].ToString();
        //                character.species = json["species"].ToString();
        //                character.gender = json["gender"].ToString();
        //                character.type = json["type"].ToString();
        //                character.origin = json["origin"];
        //                character.location = json["location"];
        //                character.image = json["image"].ToString();
        //                character.episode = JsonSerializer.Deserialize<string[]>(json["episode"].ToString());
        //                character.url = json["url"].ToString();
        //                character.created = json["created"].ToString();

        //                characters.Add(character);
        //            }
        //        }

        //        return characters;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return characters;
        //}
        #endregion

        public async Task<List<Character>> filter(string query)
        {
            List<Character> characters = new List<Character>();

            try
            {
                HttpClient client = Connection.Instance._httpClient;

                Uri url = new(client.BaseAddress, $"character/?{query}");

                HttpResponseMessage response = await client.GetAsync(url);

                var data = await response.Content.ReadFromJsonAsync<Info>();

                if (data != null)
                {
                    foreach (var item in data.results)
                    {
                        Character character = new Character();
                        JObject json = JObject.Parse(item.ToString());

                        character.id = int.Parse(json["id"].ToString());
                        character.name = json["name"].ToString();
                        character.status = json["status"].ToString();
                        character.species = json["species"].ToString();
                        character.gender = json["gender"].ToString();
                        character.type = json["type"].ToString();
                        character.origin = json["origin"];
                        character.location = json["location"];
                        character.image = json["image"].ToString();
                        character.episode = JsonSerializer.Deserialize<string[]>(json["episode"].ToString());
                        character.url = json["url"].ToString();
                        character.created = json["created"].ToString();

                        characters.Add(character);
                    }
                }

                return characters;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return characters;
        }
    }
}
