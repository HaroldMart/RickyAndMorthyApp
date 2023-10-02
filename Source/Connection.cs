using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Connection
    {
        private static Connection? instance = null;
        public HttpClient _httpClient;

        protected Connection() {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://rickandmortyapi.com/api/");
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            //UriBuilder builder = new UriBuilder(_httpClient.BaseAddress);
            //builder.Path += "/character";
        }

        public static Connection Instance
        {
            get {
                if (instance == null)
                {
                    instance = new Connection();
                }
                 
                return instance;
            }
        }
    }
}
