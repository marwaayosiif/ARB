using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ARB.Models;
using ARB.ViewModels;

namespace ARB.Controllers
{
    public class FinalAssessmentController : Controller
    {
        private ApplicationDbContext _context;

        public FinalAssessmentController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: FinalAssissment
        public ActionResult Index()
        {
            var biRads = _context.BiRads.ToList();
            var recommendation = _context.Recommendations.ToList();
            var viewModel = new FinalAssessmentViewModel
            {
                FinalAssessment = new FinalAssessment(),
                BiRads = biRads,
                Recommendations = recommendation,
            };

            return View("Index", viewModel);
        }
        [HttpPost]
        public ActionResult Save(FinalAssessment finalAssessment)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new FinalAssessmentViewModel
                {
                    FinalAssessment = finalAssessment,
                    BiRads = _context.BiRads.ToList(),
                    Recommendations = _context.Recommendations.ToList()
                };

                return View("Index", viewModel);
            }

            if (finalAssessment.Id == 0)
                _context.FinalAssessments.Add(finalAssessment);
            //else
            //{
            //    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
            //    customerInDb.Name = customer.Name;
            //    customerInDb.Birthdate = customer.Birthdate;
            //    customerInDb.MembershipTypeId = customer.MembershipTypeId;
            //    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            //}

            _context.SaveChanges();

            return RedirectToAction("Index", "GeneralInfo");
        }
    }
}