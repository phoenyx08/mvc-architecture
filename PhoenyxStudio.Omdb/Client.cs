using System;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace PhoenyxStudio.Omdb
{
    public class Client
    {
        private readonly string _apiKey;
        public Client (IOptions<ClientOptions> options)
        {
            _apiKey = options.Value.ApiKey;
        }
        async public Task<string> QueryAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://www.omdbapi.com/?apikey=" + _apiKey + "&s=drug");
            return response;
        }
        async public Task<string> SearchAsync(string searchQuery)
        {
            string response;

            var builder = new UriBuilder("http://www.omdbapi.com");
            
            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["apikey"] = _apiKey;
            query["s"] = searchQuery;
            builder.Query = query.ToString();
            string url = builder.ToString();
            
            using (var client = new HttpClient())
            {
                response = await client.GetStringAsync(url);
            }

            return response;
        }
    }
}
