using AutoMapper;
using mvc2019.DTOs;
using mvc2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}