using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using movieCollection.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace movieCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MoviesContext _movieContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MoviesContext movieContext)
        {
            _logger = logger;
            _movieContext = movieContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Movies(Movie movie)
        {
            
            if (ModelState.IsValid)
            {
                _movieContext.Add(movie);
                _movieContext.SaveChanges();
                return View("Confirmation");
            }
            ViewBag.categories = _movieContext.categories.ToList();
            return View("Movies");
            
        }
        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.categories = _movieContext.categories.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = _movieContext.movies
                .Include(x => x.category)
                .OrderBy(x => x.title)
                .ToList();
            return View(movies);
        }

        [HttpPost]
        public IActionResult Edit (Movie movie)
        {
            _movieContext.Update(movie);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.categories = _movieContext.categories.ToList();

            var movie = _movieContext.movies.Single(x => x.movieID == movieid);

            return View("Movies", movie);
        }


        public IActionResult Delete(int movieid)
        {
            _movieContext.movies.Remove(_movieContext.movies.Single(x => x.movieID == movieid));
            _movieContext.SaveChanges();
            return RedirectToAction("MovieList");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
