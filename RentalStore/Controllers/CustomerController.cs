using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc2019.Models;
using mvc2019.ViewModels;
using System.Data.Entity;

namespace mvc2019.Controllers
{
    [Authorize(Roles = RoleName.CanManageCustomers)]
    public class CustomerController : Controller
    {
        private ApplicationDbContext _dbcontext;

        public CustomerController()
        {
            _dbcontext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbcontext.Dispose();
        }

        // GET: Movie
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            //return Content(string.Format("pageindex={0}&sortBy={1}", pageIndex, sortBy));

            //var customers = GetCustomers();
            //var customers = _dbcontext.Customers.ToList();

            //var customers = _dbcontext.Customers.Include(c => c.MembershipType).ToList();            
            //var custVM = new ListCustomersViewModel(customers);
            //return View("IndexCustomer", custVM);

            if (User.IsInRole(RoleName.CanManageCustomers))
                return View("IndexCustomer");
            
            return View("IndexCustomerReadOnly");
        }

        //GET: /customer/details/id
        [Route("customer/details/{id}")]
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            var customer = _dbcontext.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            //return Content(customer.Name);
            return View("DetailsCustomer", customer);
        }

        public ActionResult New()
        {
            var new_custVM= new FormCustomerViewModel()
            {
                Memberships = _dbcontext.Memberships.ToList(),
                Customer = new Customer(),
            };
            return View("FormCustomer", new_custVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //bool result = ModelState.Remove("customer.Id");
            if (!ModelState.IsValid) 
            {
                var custVM = new FormCustomerViewModel()
                {
                    Memberships = _dbcontext.Memberships.ToList(),
                    Customer = customer,
                };
                return View("FormCustomer", custVM);
            }

            if (customer.Id == 0)
                _dbcontext.Customers.Add(customer);
            else
            {
                var customerInDb = _dbcontext.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribe = customer.IsSubscribe;
            }

            _dbcontext.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbcontext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var edit_custVM = new FormCustomerViewModel()
            {
                Customer = customer,
                Memberships = _dbcontext.Memberships.ToList()
            };

            return View("FormCustomer", edit_custVM);
        }

        private List<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer("Customer 1"),
                new Customer("Customer 2")
            };
        }

    }
}