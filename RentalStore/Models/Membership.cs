using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc2019.Models
{
    public class Membership
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public short Fee { get; set; }
        [Required]
        public short DurationInMonths { get; set; }
        [Required]
        public short Discount { get; set; }
    }
}