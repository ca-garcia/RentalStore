using mvc2019.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc2019.DTOs
{
    public class RentalDTO
    {
        public int id { get; set; }
        public CustomerDTO customer { get; set; }
        //public int customerId { get; set; }
        public MovieDTO movie { get; set; }
        public DateTime dateRented { get; set; }
        public DateTime? dateReturned { get; set; }
    }
}