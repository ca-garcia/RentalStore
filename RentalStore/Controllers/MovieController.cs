using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc2019.Models;
using mvc2019.ViewModels;
using System.Data.Entity;

namespace mvc2019.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext _dbcontext;

        public MovieController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbcontext.Dispose();
        }

        // GET: Movie
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            var movies = _dbcontext.Movies.Include(m => m.GenreType).ToList();
            var moviesVM = new ListMoviesViewModel(movies);
            return View("IndexMovie", moviesVM);
            //return Content(string.Format("pageindex={0}&sortBy={1}", pageIndex, sortBy));
        }

        //GET: /movie/details/id
        [Route("movie/details/{id}")]
        public ActionResult Details(int id)
        {
            var movie = _dbcontext.Movies.Include(m => m.GenreType).SingleOrDefault(m => m.Id == id);
            //var movie = _dbcontext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            
            //return Content(movie.Name);
            return View("DetailsMovie", movie);
            
        }

        public ActionResult New()
        {
            var new_movieVM = new FormMovieViewModel()
            {
                Genres = _dbcontext.Genres.ToList()
            };
            return View("FormMovie", new_movieVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            bool result = ModelState.Remove("movie.Id");
            if (!ModelState.IsValid)
            {
                var movieVM = new FormMovieViewModel()
                {
                    Genres = _dbcontext.Genres.ToList(),
                    Movie = movie,
                };
                return View("FormMovie", movieVM);
            }

            if (movie.Id == 0)
                _dbcontext.Movies.Add(movie);
            else
            {
                var movieInDb = _dbcontext.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreTypeId = movie.GenreTypeId;
                movieInDb.Duration = movie.Duration;
            }

            _dbcontext.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
        public ActionResult Edit(int id)
        {
            var movie = _dbcontext.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var edit_movVM = new FormMovieViewModel()
            {
                Movie = movie,
                Genres = _dbcontext.Genres.ToList()
            };

            return View("FormMovie", edit_movVM);
        }

        // GET: movie/random
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Ad Astra" };
            var customers = new List<Customer>
            {
                new Customer("Customer 1"),
                new Customer("Customer 2")
            };
            var RandVM = new RandomMovieViewModel(movie, customers);

            //return View(movie);
            return View(RandVM);
        }

        // GET: "movie/released/{year}/{month}"
        //[Route("movie/released/{year:regex(\\d{4})}/{month:range(1,12)}")]
        [Route("movie/released/{year}/{month:range(1,12)}")]
        public ActionResult ReleaseByDate(int? year, int? month=1)
        {
            return Content(year + "//" + month);
        }
    }
}