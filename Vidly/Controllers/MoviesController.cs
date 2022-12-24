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
        // GET: Movies

        public ActionResult Index()
        {
            var movies = new MovieViewModel()
            {
                Movies = new List<Movie>()
                {
                    new Movie(){Name = "Shrek!" },
                    new Movie(){Name = "Wall-e" }
                }
            };
            return View(movies);
        }

        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shrek!" };
            var customers = new List<Customer>
            {
                new Customer{Name="New Customer 1" },
                new Customer{Name="New Customer 2" }
            };
            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers= customers
            };
            return View(viewModel);
        }
        
        public ActionResult Edit(int Id)
        {
            return Content("Id=" + Id);
        }
        
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}