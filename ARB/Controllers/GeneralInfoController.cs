using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARB.Models;

namespace ARB.Controllers
{
    public class GeneralInfoController : Controller
    {
        private ApplicationDbContext _context;

        public GeneralInfoController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: GeneralInfo
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Save(GeneralInfo generalInfo)
        {
            //if (!ModelState.IsValid)
            //{
            //    Console.Write("Kher");
            //    return View("Index");
            //}

            if (generalInfo.Id == 0)
                _context.GeneralInfos.Add(generalInfo);
            //else
            //{
            //    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            //    customerInDb.Name = customer.Name;
            //    customerInDb.Birthdate = customer.Birthdate;
            //    customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //}

            _context.SaveChanges();

            return RedirectToAction("Index", "FinalAssessment");
        }
    }
}