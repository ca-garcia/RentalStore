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
    public class RentalController:Controller
    {
        private ApplicationDbContext _dbcontext;

        public RentalController()
        {
            _dbcontext = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _dbcontext.Dispose();
        }

        public ActionResult Index()
        {

            if (User.IsInRole(RoleName.CanManageCustomers))
                return View("IndexRental");

            return View("IndexRental");
        }
        public ActionResult New()
        {
            return View("FormRental");
        }

    }
}