using System;
using Microsoft.AspNetCore.Mvc;
using PhoenyxStudio.Omdb;
using System.Threading.Tasks;
using omdbapp.Models;
using System.Text.Json;

namespace omdbapp.Controllers
{
    public class MovieController : Controller
    {
        private Client _client;

        public MovieController(Client client) {
            _client = client;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Search", "Movie");
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View(new SearchModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        async public Task<IActionResult>Search([Bind("SearchQuery")] SearchModel model)
        {
            var response = await _client.SearchAsync(model.SearchQuery);
            OmdbSearchResult searchResultObject = JsonSerializer.Deserialize<OmdbSearchResult>(response);

            model.SearchResult = searchResultObject.Search;
            
            return View(model);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Search", "Movie");            
            }

            if (id == 3) // @todo: change condition here to not found index
            {
                return RedirectToAction("MovieNotFound", "Movie");
            }

            return View();
        }

        public IActionResult MovieNotFound()
        {
            return View();
        }
    }
}