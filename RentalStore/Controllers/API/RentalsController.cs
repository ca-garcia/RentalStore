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
    public class RentalsController: ApiController
    {
        private ApplicationDbContext dbContext;
        public RentalsController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET /api/rentals
        public IEnumerable<RentalDTO> getRentals()
        {
            //return dbContext.Rentals.ToList().Select(Mapper.Map<Rental, RentalDTO>);
            return dbContext.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie)
                .ToList()
                .Select(Mapper.Map<Rental, RentalDTO>);
        }

        // POST /api/rentals
        [HttpPost]
        public IHttpActionResult newRental(NewRentalsDTO newRentalsDto)
        {
            //if (!ModelState.IsValid)
            //    BadRequest();

            if (newRentalsDto.moviesIds.Count == 0)
                return BadRequest("No Movies selected for rent!");

            var customer = dbContext.Customers.SingleOrDefault(c => c.Id == newRentalsDto.customerId);

            if (customer == null)
                return BadRequest("Invalid Customer ID!");
            
            var movies = dbContext.Movies.Where(m => newRentalsDto.moviesIds.Contains(m.Id)).ToList();

            if(movies.Count != newRentalsDto.moviesIds.Count)
                return BadRequest("One or more Movies are invalid!");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie '" + movie.Name + "' is not available for rent!");
                movie.NumberAvailable--;
                var new_rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };
                dbContext.Rentals.Add(new_rental);
            }
            dbContext.SaveChanges();
            return Ok();
            //throw new NotImplementedException();
        }

        // PUT /api/rentals/{id}
        [HttpPut]
        public IHttpActionResult returnRental(int id)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var rentalDB = dbContext.Rentals.Include(r => r.Movie).SingleOrDefault(r => r.Id == id);
            if (rentalDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Mapper.Map(rentalDto, rentalDB);
            rentalDB.DateReturned = DateTime.Now;
            rentalDB.Movie.NumberAvailable++;
            dbContext.SaveChanges();
            return Ok();
        }
    }
}