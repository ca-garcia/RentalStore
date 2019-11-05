using AutoMapper;
using mvc2019.DTOs;
using mvc2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace RentalStore.Controllers.API
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext dbContext;

        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }
        // GET /api/movies
        public IEnumerable<MovieDTO> getMovies()
        {
            //return dbContext.Customers.ToList();
            return dbContext.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>);
        }
        // GET /api/movies/{id}
        public IHttpActionResult getMovie(int id)
        {
            var movie = dbContext.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                NotFound();
            //return customer;
            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }
        // POST /api/movies
        [HttpPost]
        public IHttpActionResult createMovie(Movie movie)
        {
            if (!ModelState.IsValid)
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
                BadRequest();
            //var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            dbContext.Movies.Add(movie);
            dbContext.SaveChanges();
            //customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movie);
        }
        // PUT /api/movies/{id}
        [HttpPut]
        public bool updMovie(int id, Movie movie)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieDB = dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movieDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            //Mapper.Map(customerDto, customerDB);
            movieDB.Name = movie.Name;
            movieDB.GenreTypeId= movie.GenreTypeId;
            movieDB.Duration = movie.Duration;
            dbContext.SaveChanges();
            return true;
        }
        // DELETE /api/movies/{id}
        [HttpDelete]
        public bool delMovie(int id)
        {
            var movieDB = dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movieDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            dbContext.Movies.Remove(movieDB);
            dbContext.SaveChanges();
            return true;
        }

    }
}