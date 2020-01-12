using System;
using Microsoft.AspNetCore.Mvc;
namespace omdbapp.Controllers
{
    public class MovieController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Search", "Movie");
        }

        public IActionResult Search()
        {
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