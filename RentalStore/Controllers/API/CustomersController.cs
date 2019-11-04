﻿using AutoMapper;
using mvc2019.DTOs;
using mvc2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace mvc2019.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext dbContext;

        public CustomersController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET /api/customers
        public IEnumerable <CustomerDTO> getCustomers() 
        {
            //return dbContext.Customers.ToList();
            return dbContext.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }
        // GET /api/customers/{id}
        public IHttpActionResult getCustomer(int id)
        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.Id == id);
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
            customerDto.Id = customer.Id;
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