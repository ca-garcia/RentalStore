using AutoMapper;
using mvc2019.DTOs;
using mvc2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;

namespace mvc2019.Controllers.API
{
    [Authorize(Roles = RoleName.CanManageCustomers)]
    public class CustomersController : ApiController
    {
        private ApplicationDbContext dbContext;

        public CustomersController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET /api/customers
        public IHttpActionResult getCustomers(string query = null) 
        {
            var CustomersQuery = dbContext.Customers.Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                CustomersQuery = CustomersQuery.Where(c => c.Name.Contains(query));

            var CustomerDTOs = CustomersQuery.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
            return Ok(CustomerDTOs);
            //return dbContext.Customers.ToList();
        }
        // GET /api/customers/{id}
        public IHttpActionResult getCustomer(int id)
        {
            var customer = dbContext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                NotFound();
            //return customer;
            return Ok(Mapper.Map<Customer,CustomerDTO>(customer));
        }
        // POST /api/customers
        [HttpPost]
        public IHttpActionResult createCustomer(CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                BadRequest();
            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            customerDto.id= customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }
        // PUT /api/customers/{id}
        [HttpPut]
        public bool updCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerDB = dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerDB);
            //customerDB.Name = customer.Name;
            //customerDB.IsSubscribe= customer.IsSubscribe;
            //customerDB.MembershipTypeId = customer.MembershipTypeId;
            dbContext.SaveChanges();
            return true;
        }
        // DELETE /api/customers/{id}
        [HttpDelete]
        public bool delCustomer(int id)
        {
            var customerDB = dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customerDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            dbContext.Customers.Remove(customerDB);
            dbContext.SaveChanges();
            return true;
        }
    }
}
