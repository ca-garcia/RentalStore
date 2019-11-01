using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc2019.Models
{
    public class CustomValidationMovie: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (!Int32.TryParse(movie.Duration.ToString(), out int tmp))
                return new ValidationResult("Movie duration must be a number!");
            if (movie.Duration > Movie.min_duration && movie.Duration < Movie.max_duration)
                return ValidationResult.Success;
            else
                return new ValidationResult("Movie duration must have value between 60 - 600 minutes!");

            //return base.IsValid(value, validationContext);
        }
    }
}