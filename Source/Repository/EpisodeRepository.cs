using Newtonsoft.Json.Linq;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class EpisodeRepository
    {
        public async Task<List<Episode>> getAll()
        {
            List<Episode> episodes = new List<Episode>();

            try
            {
                HttpClient client = Connection.Instance._httpClient;

                Uri url = new(client.BaseAddress, "location");

                HttpResponseMessage response = await client.GetAsync(url);

                var data = await response.Content.ReadFromJsonAsync<Info>();

                if (data != null)
                {
                    foreach (var item in data.results)
                    {
                        Episode episode = new Episode();
                        JObject json = JObject.Parse(item.ToString());

                        episode.id = int.Parse(json["id"].ToString());
                        episode.name = json["name"].ToString();
                        episode.air_date = json["air_date"].ToString();
                        episode.episode = json["episode"].ToString();
                        episode.characters = JsonSerializer.Deserialize<string[]>(json["characters"].ToString());
                        episode.url = json["url"].ToString();
                        episode.created = json["created"].ToString();

                        episodes.Add(episode);
                    }
                }

                return episodes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return episodes;
        }

        //public async Task<Episode> get(string idEpisode)
        //{
        //    try
        //    {
        //        HttpClient client = Connection.Instance._httpClient;

        //        Uri url = new(client.BaseAddress, $"episode/{idEpisode}");

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        var data = await response.Content.ReadFromJsonAsync<Episode>();

        //        Episode episode = data;

        //        Console.WriteLine(data.name);

        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return new Episode { };
        //}

        public async Task<List<Episode>> getMultiple(string[] list)
        {
            List<Episode> episodes = new List<Episode>();

            string multipleEpisodes = "";
            foreach (string item in list)
            {
                multipleEpisodes += $"{item},";
            }

            try
            {
                HttpClient client = Connection.Instance._httpClient;

                Uri url = new(client.BaseAddress, $"episode/{multipleEpisodes}");

                HttpResponseMessage response = await client.GetAsync(url);

                var data = await response.Content.ReadFromJsonAsync<List<object>>();

                if (data != null)
                {
                    foreach (var item in data)
                    {
                        Episode episode = new Episode();
                        JObject json = JObject.Parse(item.ToString());

                        episode.id = int.Parse(json["id"].ToString());
                        episode.name = json["name"].ToString();
                        episode.air_date = json["air_date"].ToString();
                        episode.episode = json["episode"].ToString();
                        episode.characters = JsonSerializer.Deserialize<string[]>(json["characters"].ToString());
                        episode.url = json["url"].ToString();
                        episode.created = json["created"].ToString();

                        episodes.Add(episode);
                    }
                }

                return episodes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return episodes;
        }

        public async Task<List<Episode>> filter(string query)
        {
            List<Episode> episodes = new List<Episode>();

            try
            {
                HttpClient client = Connection.Instance._httpClient;

                Uri url = new(client.BaseAddress, $"location/?{query}");

                HttpResponseMessage response = await client.GetAsync(url);

                var data = await response.Content.ReadFromJsonAsync<Info>();

                if (data != null)
                {
                    foreach (var item in data.results)
                    {
                        Episode episode = new Episode();
                        JObject json = JObject.Parse(item.ToString());

                        episode.id = int.Parse(json["id"].ToString());
                        episode.name = json["name"].ToString();
                        episode.air_date = json["air_date"].ToString();
                        episode.episode = json["episode"].ToString();
                        episode.characters = JsonSerializer.Deserialize<string[]>(json["characters"].ToString());
                        episode.url = json["url"].ToString();
                        episode.created = json["created"].ToString();

                        episodes.Add(episode);
                    }
                }

                return episodes;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return episodes;
        }
    }
}
