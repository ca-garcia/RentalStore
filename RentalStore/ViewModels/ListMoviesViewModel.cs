using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc2019.Models;

namespace mvc2019.ViewModels
{
    public class ListMoviesViewModel
    {
        public ListMoviesViewModel(List<Movie> movies)
        {
            Movies = movies;
        }

        public List<Movie> Movies { get; set; }
    }
}