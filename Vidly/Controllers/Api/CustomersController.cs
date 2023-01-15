using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Core;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _unitOfWork.Customers.GetAll().Select(Mapper.Map<Customer, CustomerDto>);
        }

        public CustomerDto GetCustomer(int id)
        {
            var customer = _unitOfWork.Customers.Get(id);
            if(customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer, CustomerDto>( customer);
        }
        [HttpPost]
        public CustomerDto CreateCustomer(CustomerDto customerDto)
        {
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _unitOfWork.Customers.Add(customer);
            _unitOfWork.Complete();
            customerDto.Id = customer.Id;
            return customerDto;
        }

        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            var customerInDb = _unitOfWork.Customers.Get(id);
            if(customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map(customerDto, customerInDb);
            _unitOfWork.Complete();
        }

        public void DeleteCustomer(int id)
        {
            var customerInDb = _unitOfWork.Customers.Get(id);
            if (customerInDb == null) 
            {
                throw new HttpResponseException(HttpStatusCode.NotFound) ;
            }

            _unitOfWork.Customers.Remove(customerInDb);
            _unitOfWork.Complete();
        }


    }
}
