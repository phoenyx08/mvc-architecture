using System;
using Microsoft.AspNetCore.Mvc;
using PhoenyxStudio.Omdb;
using System.Threading.Tasks;

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

        async public Task<IActionResult> Search()
        {
            //var client = new Client();

            var response = await _client.QueryAsync();

            ViewData["response"] = response;

            return View();
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