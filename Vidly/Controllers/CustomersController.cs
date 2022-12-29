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
    public class CustomersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Route("Customers/")]
        public ActionResult Index()
        {
            var customers = new CustomersViewModel()
            {
                Customers = _unitOfWork.Customers.GetAllWithMembershiptype()
            };
            return View(customers);
        }

        [Route("Customers/Details/{Id:int}")]
        public ActionResult Details(int Id)
        {
            var customer = new CustomerDetailViewModel()
            {
                Customer = _unitOfWork.Customers.GetWithMembershipType(Id)
            };

            return View(customer);
        }

        public ActionResult New()
        {
            var viewModel = new NewCustomerViewModel()
            { 
                MembershipTypes = _unitOfWork.MembershipType.GetAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Customers");
        }
    }
}