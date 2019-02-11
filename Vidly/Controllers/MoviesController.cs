using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random

        

        private ApplicationDbContext _context;
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

       

        public ActionResult Edit (int id)
        {
            return Content("id =" +id);
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();

            return View(movies);

        }


        public ActionResult Create()
        {
            var genreList = _context.Genres.ToList();
            var viewModel = new MovieFromViewModel
            {
                Genre = genreList
            };
            return View("MovieForm",viewModel);
        }





        [Route("movies/released/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
         public ActionResult ByReleaseYear (int? year, int? month)
        {
            if (!year.HasValue)
                year = 1990;
            if (!month.HasValue)
                month = 01;
            return Content(year + "/" + month);
        }

        public ActionResult EditMovies(int id)
        {

            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            var GenreList = _context.Genres.ToList();
            var viewModel = new MovieFromViewModel
            {
                Movie = movie,
                Genre = GenreList
            };

            return View("MovieForm",viewModel);
        }
        //public ActionResult MovieDetails (string Name)
        //{

        //    return HttpNotFound();

        //}

        [HttpPost]
        public ActionResult Save(Movie movie)
        {

            if (movie.Id == 0)
                _context.Movies.Add(movie);
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.Stock = movie.Stock;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

       
    }
}