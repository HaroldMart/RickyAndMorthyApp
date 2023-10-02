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
    public class Locations
    {
        public async Task<List<Location>> getAllLocations()
        {
            List<Location> locations = new List<Location>();

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
        public async Task<Location> getLocation(string idLocation)
        {
            try
            {
                HttpClient client = Connection.Instance._httpClient;

                Uri url = new(client.BaseAddress, $"location/{idLocation}");
                Console.WriteLine(url);

                HttpResponseMessage response = await client.GetAsync(url);

                var data = await response.Content.ReadFromJsonAsync<Location>();

                Location character = data;

                Console.WriteLine(data.name);

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new Location { };
        }

        public async Task<List<Location>> getMultipleLocations(string[] list)
        {
            List<Location> locations = new List<Location>();

            string multipleLocations = "";
            foreach (string item in list)
            {
                multipleLocations += $"{item},";
            }

            try
            {
                HttpClient client = Connection.Instance._httpClient;

                Uri url = new(client.BaseAddress, $"location/{multipleLocations}");

                HttpResponseMessage response = await client.GetAsync(url);

                var data = await response.Content.ReadFromJsonAsync<List<object>>();

                if (data != null)
                {
                    foreach (var item in data)
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

        public async Task<List<Location>> filterLocations(string query)
        {
            List<Location> locations = new List<Location>();

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
