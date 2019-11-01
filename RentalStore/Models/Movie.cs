using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc2019.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name{ get; set; }
        public Genre GenreType{ get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreTypeId { get; set; }
        [CustomValidationMovie]
        public int Duration{ get; set; }

        public static readonly short min_duration = 60;
        public static readonly short max_duration = 600;
    }
}