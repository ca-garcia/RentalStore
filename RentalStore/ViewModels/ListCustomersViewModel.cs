using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mvc2019.Models;

namespace mvc2019.ViewModels
{
    public class ListCustomersViewModel
    {
        public ListCustomersViewModel(List<Customer> customers)
        {
            Customers= customers;
        }

        public List<Customer> Customers{ get; set; }
    }
}