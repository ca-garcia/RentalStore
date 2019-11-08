using AutoMapper;
using mvc2019.DTOs;
using mvc2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Data.Entity;


namespace RentalStore.Controllers.API
{
    [Authorize(Roles = RoleName.CanManageMovies)]
    public class MoviesController : ApiController
    {
        private ApplicationDbContext dbContext;

        public MoviesController()
        {
            dbContext = new ApplicationDbContext();
        }
        [AllowAnonymous]
        // GET /api/movies
        public IHttpActionResult getMovies(string query = null)
        {
            var MoviesQuery = dbContext.Movies.Include(m => m.GenreType);

            if (!String.IsNullOrWhiteSpace(query))
                MoviesQuery = MoviesQuery.Where(m => m.Name.Contains(query));

            var MoviesDTOs = MoviesQuery.ToList().Select(Mapper.Map<Movie, MovieDTO>);
            return Ok(MoviesDTOs);
            //return dbContext.Customers.ToList();
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
        public IHttpActionResult delMovie(int id)
        {
            var movieDB = dbContext.Movies.SingleOrDefault(m => m.Id == id);
            if (movieDB == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            dbContext.Movies.Remove(movieDB);
            dbContext.SaveChanges();
            return Ok();
        }

    }
}