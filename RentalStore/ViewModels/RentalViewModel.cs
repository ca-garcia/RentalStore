using mvc2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc2019.ViewModels
{
    public class RentalViewModel
    {
        public Customer Customer { get; set; }
        public List<Movie> Movies{ get; set; }
    }
}