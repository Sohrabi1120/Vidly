using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Persistence.Repositories;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        [Route("Customers/")]
        public ActionResult Index()
        {
            var customers = new CustomersViewModel()
            {
                Customers = new CustomerRepository(new ApplicationDbContext()).GetAll()
            };
            return View(customers);
        }

        [Route("Customers/Details/{Id:int}")]
        public ActionResult Details(int Id)
        {
            var customer = new CustomerDetailViewModel()
            {
                Customer = new CustomerRepository(new ApplicationDbContext()).Get(Id)
            };

            return View(customer);
        }
    }
}