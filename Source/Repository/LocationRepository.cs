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
    public class LocationRepository
    {
        private static readonly Random random = new();
        private readonly HttpClient client = Connection.Instance._httpClient;

        public async Task<int[]> getInfo()
        {
            Uri url = new(client.BaseAddress, $"location");

            HttpResponseMessage response = await client.GetAsync(url);

            var data = await response.Content.ReadFromJsonAsync<Info>();

            JObject json = JObject.Parse(data.info.ToString());
            int count = int.Parse(json["count"].ToString());
            int pages = int.Parse(json["pages"].ToString());
            int[] list = new int[] { count, pages };

            return list;
        }

        public async Task<List<Location>> getAll(int totalPages)
        {
            List<Location> locations = new();

            try
            {
                for (int i = 1; i <= 3; i++)
                {
                    int page = random.Next(1, totalPages);
                    string query = $"?page={page}";

                    Uri url = new(client.BaseAddress, $"location{query}");

                    HttpResponseMessage response = await client.GetAsync(url);

                    var data = await response.Content.ReadFromJsonAsync<Info>();

                    if (data != null)
                    {
                        foreach (var item in data.results)
                        {
                            Location location = new();
                            JObject json = JObject.Parse(item.ToString());

                            location.id = int.Parse(json["id"].ToString());
                            location.name = json["name"].ToString();
                            location.type = json["type"].ToString();
                            location.dimension = json["dimension"].ToString();
                            location.residents = JsonSerializer.Deserialize<string[]>(json["residents"].ToString());
                            location.url = json["url"].ToString();
                            location.created = json["created"].ToString();

                            locations.Add(location);
                        }
                    }
                }

                return locations;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return locations;
        }

        #region "get"
        //public async Task<Location> get(string idLocation)
        //{
        //    try
        //    {
        //        HttpClient client = Connection.Instance._httpClient;

        //        Uri url = new(client.BaseAddress, $"location/{idLocation}");
        //        Console.WriteLine(url);

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        var data = await response.Content.ReadFromJsonAsync<Location>();

        //        Location character = data;

        //        Console.WriteLine(data.name);

        //        return data;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return new Location { };
        //}
        #endregion

        #region "getMultiple"
        //public async Task<List<Location>> getMultiple(string[] list)
        //{
        //    List<Location> locations = new List<Location>();

        //    string multipleLocations = "";
        //    foreach (string item in list)
        //    {
        //        multipleLocations += $"{item},";
        //    }

        //    try
        //    {
        //        HttpClient client = Connection.Instance._httpClient;

        //        Uri url = new(client.BaseAddress, $"location/{multipleLocations}");

        //        HttpResponseMessage response = await client.GetAsync(url);

        //        var data = await response.Content.ReadFromJsonAsync<List<object>>();

        //        if (data != null)
        //        {
        //            foreach (var item in data)
        //            {
        //                Location location = new Location();
        //                JObject json = JObject.Parse(item.ToString());

        //                location.id = int.Parse(json["id"].ToString());
        //                location.name = json["name"].ToString();
        //                location.type = json["type"].ToString();
        //                location.dimension = json["dimension"].ToString();
        //                location.residents = JsonSerializer.Deserialize<string[]>(json["residents"].ToString());
        //                location.url = json["url"].ToString();
        //                location.created = json["created"].ToString();

        //                locations.Add(location);
        //            }
        //        }

        //        return locations;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.Message);
        //    }

        //    return locations;
        //}
        #endregion

        public async Task<List<Location>> filter(string query)
        {
            List<Location> locations = new List<Location>();

            try
            {
                Uri url = new(client.BaseAddress, $"location/?{query}");

                HttpResponseMessage response = await client.GetAsync(url);

                var data = await response.Content.ReadFromJsonAsync<Info>();

                if (data != null)
                {
                    foreach (var item in data.results)
                    {
                        Location location = new Location();
                        JObject json = JObject.Parse(item.ToString());

                        location.id = int.Parse(json["id"].ToString());
                        location.name = json["name"].ToString();
                        location.type = json["type"].ToString();
                        location.dimension = json["dimension"].ToString();
                        location.residents = JsonSerializer.Deserialize<string[]>(json["residents"].ToString());
                        location.url = json["url"].ToString();
                        location.created = json["created"].ToString();

                        locations.Add(location);
                    }
                }

                return locations;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return locations;
        }
    }
}
