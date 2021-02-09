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
        // GET api/<ComboBox>
        [Route("GetMassDensities")]

        public IHttpActionResult GetMassDensities()
        {
            var test = _context.MassDensity.ToList();

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
