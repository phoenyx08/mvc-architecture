using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace PhoenyxStudio.Omdb
{
    public class Client
    {
        async public Task<string> QueryAsync()
        {
            HttpClient client = new HttpClient();
            var response = await client.GetStringAsync("http://www.omdbapi.com/?apikey=[apikeyhere]]&s=girl");
            return response;
        }
    }
}
