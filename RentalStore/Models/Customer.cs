using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc2019.Models
{
    public class Customer
    {
        public Customer() { }
        public Customer(string name)
        {
            Name = name;
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Insert Client´s name!")]
        [StringLength(255)]
        public string Name{ get; set; }
        public bool IsSubscribe { get; set; }
        public Membership MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public int? MembershipTypeId { get; set; }
    }
}