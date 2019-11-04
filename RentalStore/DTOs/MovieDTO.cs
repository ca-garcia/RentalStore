using mvc2019.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc2019.DTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public int GenreTypeId { get; set; }
        [CustomValidationMovie]
        public int Duration { get; set; }
    }
}