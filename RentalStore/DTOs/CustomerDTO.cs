using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc2019.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; set; }
        [StringLength(255)]
        [Required(ErrorMessage = "Insert Client´s name!")]
        public string Name { get; set; }
        public bool IsSubscribe { get; set; }
        public int? MembershipTypeId { get; set; }
    }
}