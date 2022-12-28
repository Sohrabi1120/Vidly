using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Core;
using Vidly.Models;
using Vidly.Persistence.Repositories;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public MoviesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Route("Movies")]
        public ActionResult Index()
        {
            var movies = new MoviesViewModel()
            {
                Movies = _unitOfWork.Movies.GetAllWithGenre()
            };
            return View(movies);
        }
        [Route("Movies/Details/{Id:int}")]
        public ActionResult Details(int Id)
        {
            var movie = new MovieDetailViewModel()
            {
                Movie = _unitOfWork.Movies.GetWithGenre(Id)
            };
            return View(movie);
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