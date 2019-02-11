using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {

            var movie = new Movie() {Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer {Id= 1, Name="Giri"  },
                new Customer { Id = 2, Name ="Medi"}
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            

            return View(viewModel);
        }

        public ActionResult Edit (int id)
        {
            return Content("id =" +id);
        }

        public ActionResult Index()
        {
            var tempMovieList = new List<Movie>
            {
              
                
                        new Movie {Name = "Movie1"},
                new Movie {Name = "Movie2"},
                new Movie {Name = "Movie3"}


               


            };

            var movieList = new MovieListViewModel();
            movieList.MovieList = tempMovieList;

            return View(movieList);
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


        public ActionResult MovieDetails (string Name)
        {

            return HttpNotFound();

        }

       
    }
}