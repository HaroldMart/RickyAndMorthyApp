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
using System.Collections;

namespace Repository.Data
{
    public class CharacterRepository
    {
        private static readonly  Random random = new();
        private readonly HttpClient client = Connection.Instance._httpClient;

        public async Task<int[]> getInfo()
        {
            Uri url = new(client.BaseAddress, $"character");

            HttpResponseMessage response = await client.GetAsync(url);

            var data = await response.Content.ReadFromJsonAsync<Info>();

            JObject json = JObject.Parse(data.info.ToString());
            int count = int.Parse(json["count"].ToString());
            int pages = int.Parse(json["pages"].ToString());
            int[] list = new int[] { count, pages };

            return list;
        }

        public async Task<List<Character>> getAll(int totalPages)
        {
            List<Character> characters = new();

            try
            {
                for(int i = 1; i <= 3; i++)
                {
                    int page = random.Next(1, totalPages);
                    string query = $"?page={page}";

                    Uri url = new(client.BaseAddress, $"character{query}");

                    HttpResponseMessage response = await client.GetAsync(url);

                    var data = await response.Content.ReadFromJsonAsync<Info>();

                    if (data != null)
                    {
                        foreach (var item in data.results)
                        {
                            Character character = new();
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

        public async Task<List<Character>> getMultiple(int[] list)
        {
            List<Character> characters = new List<Character>();

            string multipleCharacters = "";
            foreach (var item in list)
            {
                multipleCharacters += $"{item},";
            }

            try
            {
                Uri url = new(client.BaseAddress, $"character/{multipleCharacters}");

                HttpResponseMessage response = await client.GetAsync(url);

                var data = await response.Content.ReadFromJsonAsync<List<object>>();

                if (data != null)
                {
                    foreach (var item in data)
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

        public async Task<List<Character>> filter(string query)
        {
            List<Character> characters = new List<Character>();

            try
            {
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
