using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using ARB.Models;
using System.Data.Entity;
using ARB.ViewModels;
namespace ARB.Controllers
{
    public class ClinicalInfoController : Controller
    {
        private ApplicationDbContext _context;

        public ClinicalInfoController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: ClinicalInfo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult New()
        {
            var asymmetries = _context.Asymmetries.ToList();
            var massMargin = _context.MassMargin.ToList();
            var massDensity = _context.MassDensity.ToList();
            var clacificationTypicallyBenign = _context.ClacificationTypicallyBenign.ToList();
            var clacificationSuspiciousMorphology = _context.ClacificationSuspiciousMorphology.ToList();
            var clacificationDistribution = _context.ClacificationDistribution.ToList();
            var quadrant = _context.Quadrants.ToList();
            var clockFace = _context.ClockFaces.ToList();

            var viewModel = new ClinicalInfoViewModel
            {
                ClinicalInfo = new ClinicalInfo(),
                Asymmetries = asymmetries,
                MassMargin = massMargin,
                MassDensity = massDensity,
                ClacificationTypicallyBenign = clacificationTypicallyBenign,
                ClacificationDistribution = clacificationDistribution,
                ClacificationSuspiciousMorphology = clacificationSuspiciousMorphology,
                Quadrant = quadrant,
                ClockFace = clockFace

            };
           
            return View("Index", viewModel);
        }

        [HttpPost]
        public ActionResult Save(ClinicalInfo clinicalInfo)
        {

            if (clinicalInfo.Id == 0)
                _context.ClinicalInfos.Add(clinicalInfo);
            else
            {
                var clinicalInfoDB = _context.ClinicalInfos.Single(c => c.Id == clinicalInfo.Id);
                // Mapper.Map(customer,clinicalInfoDB);
                clinicalInfoDB.Asymmetries = clinicalInfo.Asymmetries;
                clinicalInfoDB.BreastCompostion = clinicalInfo.BreastCompostion;
                clinicalInfoDB.ClockFace = clinicalInfo.ClockFace;
                clinicalInfoDB.Depth = clinicalInfo.Depth;
                clinicalInfoDB.DistanceFromTheNipple = clinicalInfo.DistanceFromTheNipple;
                clinicalInfoDB.Distribution = clinicalInfo.Distribution;
                clinicalInfoDB.Features = clinicalInfo.Features;
                clinicalInfoDB.Laterality = clinicalInfo.Laterality;
                clinicalInfoDB.MassDensity = clinicalInfo.MassDensity;
                clinicalInfoDB.MassMargin = clinicalInfo.MassMargin;
                clinicalInfoDB.MassShape = clinicalInfo.MassShape;
                clinicalInfoDB.NumOfMass = clinicalInfo.NumOfMass;
                clinicalInfoDB.Quadrant = clinicalInfo.Quadrant;
                clinicalInfoDB.SuspiciousMorphology = clinicalInfo.SuspiciousMorphology;
                clinicalInfoDB.TypicallyBenign = clinicalInfo.TypicallyBenign;

            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

       /* public ActionResult Edit(int id)
        {
            var customer = _context.ClinicalInfos.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
          
            return View();
        }*/

      /*  

        public ActionResult Details(int id)
        {
            *//*  var customer = new Customer() { Name ="Customer"+id , Id =id};*//*
            var customer = _context.ClinicalInfos.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }


    }*/

}
}