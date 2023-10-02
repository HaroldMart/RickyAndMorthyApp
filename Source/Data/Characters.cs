using Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data
{
    public class Characters
    {
        public Characters() { }

        public async Task<Character> getCharacter() {
            try
            {
                var client = Connection.Instance._httpClient;

                Uri url = new(client.BaseAddress, "character/2");
                Console.WriteLine(url);

                HttpResponseMessage response = await client.GetAsync(url);
              
                var data = await response.Content.ReadFromJsonAsync<Character>();
                //var info = await response.Content.ReadAsStringAsync();

                Character character = data;

                Console.WriteLine(data.name);

                return data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return new Character { };
        } 
    }
}
