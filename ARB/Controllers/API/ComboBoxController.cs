using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ARB.Models;

namespace ARB.Controllers.API
{
    [RoutePrefix("api/combobox")]
    public class ComboBoxController : ApiController
    {
        private ApplicationDbContext _context;

        public ComboBoxController()
        {
            _context = new ApplicationDbContext();
        }

        [Route("GetBiRads")]

        public IHttpActionResult GetBiRads()
        {
            var test = _context.BiRads.ToList();

            return Ok(test);
        }

        [Route("GetRecommendation")]

        public IHttpActionResult GetRecommendation()
        {
            var test = _context.Recommendations.ToList();

            return Ok(test);
        }
        //Asymmetries

        [Route("GetAsymmetries")]

        public IHttpActionResult GetAsymmetries()
        {
            var test = _context.Asymmetries.ToList();

            return Ok(test);
        }

        [Route("GetMassMargin")]

        public IHttpActionResult GetMassMargin()
        {
            var test = _context.MassMargin.ToList();

            return Ok(test);
        }


        // GET api/<ComboBox>
        [Route("GetMassDensities")]

        public IHttpActionResult GetMassDensities()
        {
            var test = _context.MassDensity.ToList();

            return Ok(test);
        }

        [Route("GetQuadrants")]

        public IHttpActionResult GetQuadrants()
        {
            var test = _context.Quadrants.ToList();

            return Ok(test);
        }

        [Route("GetClockFaces")]

        public IHttpActionResult GetClockFaces()
        {
            var test = _context.ClockFaces.ToList();

            return Ok(test);
        }

        [Route("GetClacificationTypicallyBenign")]

        public IHttpActionResult GetClacificationTypicallyBenign()
        {
            var test = _context.ClacificationTypicallyBenign.ToList();

            return Ok(test);
        }

        [Route("GetClacificationSuspiciousMorphology")]

        public IHttpActionResult GetClacificationSuspiciousMorphology()
        {
            var test = _context.ClacificationSuspiciousMorphology.ToList();

            return Ok(test);
        }

        [Route("GetClacificationDistribution")]

        public IHttpActionResult GetClacificationDistribution()
        {
            var test = _context.ClacificationDistribution.ToList();

            return Ok(test);
        }

        // GET api/<ComboBox>
        [Route("GetCombo")]

        public IHttpActionResult Getcombo()
        {
            var test = _context.ComboBox.ToList();

            return Ok(test);
        }

    }
}
