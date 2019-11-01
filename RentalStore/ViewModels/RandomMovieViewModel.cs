using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc2019.Models;

namespace mvc2019.ViewModels
{
    public class RandomMovieViewModel
    {
        public RandomMovieViewModel(Movie randMovie, List<Customer> customers)
        {
            RandMovie = randMovie;
            Customers = customers;
        }

        public Movie RandMovie { get; set; }
        public List<Customer> Customers{ get; set; }
    }
}