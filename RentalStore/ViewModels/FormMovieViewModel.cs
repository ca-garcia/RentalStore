using mvc2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc2019.ViewModels
{
    public class FormMovieViewModel
    {
        public Movie Movie{ get; set; }
        public List<Genre> Genres{ get; set; }
    }
}