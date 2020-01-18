using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PhoenyxStudio.Omdb;
using System.Threading.Tasks;
using omdbapp.Models;
using System.Text.Json;
using omdbapp.Data;

namespace omdbapp.Controllers
{
    public class MovieController : Controller
    {
        private Client _client;
        private readonly ApplicationDbContext _context;

        public MovieController(Client client, ApplicationDbContext context) {
            _client = client;
            _context = context;
        }
        public IActionResult Index()
        {
            return RedirectToAction("Search", "Movie");
        }

        [Route("Movie/Ajax/Search")]
        [HttpPost]
        async public Task<object> AjaxSearchAsync(string searchQuery, string page)
        {
            string response = await _client.SearchAsync(searchQuery, page);
            OmdbSearchResult searchResultObject = JsonSerializer.Deserialize<OmdbSearchResult>(response);
            return new {result = searchResultObject};
        }

        [HttpGet]
        public IActionResult Search()
        {
            return View(new SearchModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        async public Task<IActionResult> Search([Bind("SearchQuery")] SearchModel model)
        {
            string response = await _client.SearchAsync(model.SearchQuery);
            OmdbSearchResult searchResultObject = JsonSerializer.Deserialize<OmdbSearchResult>(response);
            model.SearchResult = searchResultObject.Search;
            model.Totals = searchResultObject.totalResults;
            return View(model);
        }

        public async Task<IActionResult> Details(string imdbId)
        {
            if (imdbId == null)
            {
                return RedirectToAction("Search", "Movie");            
            }

            MovieDetailsModel movie = _context
                .MovieDetailsModels
                .Where(movie => movie.imdbID == imdbId)
                .Include(movie => movie.Ratings)
                .FirstOrDefault();

            if (movie == null) {
                string response = await _client.QueryByImdbIdAsync(imdbId);
                movie = JsonSerializer.Deserialize<MovieDetailsModel>(response);

                if (movie.Response == "False")
                {
                    return RedirectToAction("MovieNotFound", "Movie");
                }

                await _context.AddAsync(movie);
                await _context.SaveChangesAsync();
            }
            
            return View(movie);
        }

        public IActionResult MovieNotFound()
        {
            return View();
        }
    }
}