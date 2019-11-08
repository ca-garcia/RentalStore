using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc2019.DTOs
{
    public class NewRentalsDTO
    {
        //public int id { get; set; }
        public int customerId { get; set; }
        public List<int> moviesIds { get; set; }
    }
}