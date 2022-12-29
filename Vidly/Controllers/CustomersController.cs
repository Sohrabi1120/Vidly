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
            var viewModel = new CustomerFormViewModel()
            { 
                MembershipTypes = _unitOfWork.MembershipType.GetAll()
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
                _unitOfWork.Customers.Add(customer);
            else
            {
                var customerInDb = _unitOfWork.Customers.Get(customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _unitOfWork.Complete();
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);

            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _unitOfWork.MembershipType.GetAll()
            };
            return View("CustomerForm", viewModel);
        }
    }
}