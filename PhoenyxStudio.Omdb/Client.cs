using System;
using System.Web;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using System.Collections.Specialized;

namespace PhoenyxStudio.Omdb
{
    /// <summary>
    /// Main class of the OMDb Api Client Service
    /// </summary>
    /// <remarks>
    /// <para>The class contains methods for sending search API-requests and request for movie details</para>
    /// <para>Method for sending search request has two overloads. First one sends just query string, although second one mentions also page of search results to query not only firs 10 search results</para>
    /// </remarks>
    public class Client
    {
        /// <value>
        /// This private property holds OMDb Api Key, passed as parameter to the constructor
        /// </value>
        private readonly string _apiKey;

        /// <value>
        /// Api URL participating in all the requests. It is constant because it will not be modified
        /// </value>
        private const string _apiUrl = "http://www.omdbapi.com";

        /// <summary>
        /// Class constructor. Accepts instance of IOptions as input value to facilitate injection of the service as dependency. We juse pass input parameters to the private property _apiKey
        /// <summary>
        /// <param name="options">
        /// Microsoft.Extensions.Options.IOptions instance needed to instantiate an object of the class
        /// </param>
        public Client (IOptions<ClientOptions> options)
        {
            _apiKey = options.Value.ApiKey;
        }

        ///<summary>
        /// Sends request for search of the the movie to the IMDb Api
        ///</summary>
        ///<param name="searchQuery">
        /// The String inserted by user in the search form
        ///</param>
        ///<returns>
        /// Asynchronously returns json-response from the IMDb Api
        ///</returns>
        async public Task<string> SearchAsync(string searchQuery)
        {
            var query = new NameValueCollection();

            query["s"] = searchQuery;
            
            return await queryAsync(query);
        }

        ///<summary>
        /// Sends request for search of the the movie to the IMDb Api providing search string and desired page of search result
        ///</summary>
        ///<param name="searchQuery">
        /// The String inserted by user in the search form
        ///</param>
        ///<param name="page">
        /// The String inserted by user in the search form
        ///</param>
        ///<returns>
        /// Asynchronously returns json-response from the IMDb Api
        ///</returns>
        async public Task<string> SearchAsync(string searchQuery, string page)
        {
            var query = new NameValueCollection();

            query["s"] = searchQuery;
            query["page"] = page;

            return await queryAsync(query);
        }

        ///<summary>
        /// Sends request for details of the movie to the IMDb Api providing imdbId as parameter
        ///</summary>
        ///<param name="imdbId">
        /// The String inserted by user in the search form
        ///</param>
        ///<returns>
        /// Asynchronously returns json-response from the IMDb Api with the movie details
        ///</returns>
        async public Task<string> QueryByImdbIdAsync(string imdbId)
        {
            var query = new NameValueCollection();
            
            query["i"] = imdbId;
            query["plot"] = "full";

            return await queryAsync(query);
        }

        ///<summary>
        /// Private method ensuring work of all the public ones, which use it to actually send requrests
        ///</summary>
        ///<param name="args">
        /// Name-value collection of get-parameters attached to the query string being sent to the API
        ///</param>
        ///<returns>
        /// Asynchronously returns json-response from the IMDb Api coniaining results depending on <paramref name="args"/>
        ///</returns>
        async private Task<string> queryAsync(NameValueCollection args)
        {
            string response;
            var builder = new UriBuilder(_apiUrl);

            builder.Port = -1;
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["apikey"] = _apiKey;
            query.Add(args);
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
