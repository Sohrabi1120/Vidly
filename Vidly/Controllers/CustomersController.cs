using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        [Route("Customers/")]
        public ActionResult Index()
        {
            var customers = new CustomersViewModel()
            {
                Customers = new List<Customer> 
                { 
                    new Customer{Name = "John Smith", Id = 1},
                    new Customer{Name = "Mary Williams", Id = 2}
                }
                
            };
            return View(customers);
        }

        [Route("Customers/Details/{Id:int}")]
        public ActionResult Details(int Id)
        {
            var customers = new CustomersViewModel()
            {
                Customers = new List<Customer>
                {
                    new Customer{Name = "John Smith", Id = 1},
                    new Customer{Name = "Mary Williams", Id = 2}
                }

            };
            var result = customers.Customers.Skip(Id - 1).FirstOrDefault();
            return View(new CustomersViewModel() 
            {
                Customers= new List<Customer> { result}
            });
        }
    }
}