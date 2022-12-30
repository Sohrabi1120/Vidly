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

        public ActionResult New()
        {
            var viewModel = new MovieFormViewModel()
            {
                Genres = _unitOfWork.Genres.GetAll()
            };
            return View("MovieForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Movie movie)
        {
            if (movie.Id == 0)
                _unitOfWork.Movies.Add(movie);
            else
            {
                var movieInDb = _unitOfWork.Movies.Get(movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate= movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.DateAdded = movie.DateAdded;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Movies");
        }

        public ActionResult Edit(int id)
        {
            var movie = _unitOfWork.Movies.Get(id);
            if (movie== null)
                return HttpNotFound();
            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _unitOfWork.Genres.GetAll()
            };
            return View("MovieForm" , viewModel);
        }
        
        

    }
}