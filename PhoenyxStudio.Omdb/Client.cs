using System;
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
    }
}
