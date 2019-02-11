using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

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