﻿using System;
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
        public ActionResult Index(int? pageIndex, string orderBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;

            if (String.IsNullOrWhiteSpace(orderBy))
                orderBy = "Name";
            return Content(String.Format("pageIndex={0}&orderBy={1}", pageIndex, orderBy));
        }
        [Route("movies/released/{year}/{month:regex(\\d{4}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(year + "/" + month);
        }

    }
}