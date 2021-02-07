using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ARB.Models;

namespace ARB.Controllers.API
{
    public class ComboBoxController : ApiController
    {
        private ApplicationDbContext _context;

        public ComboBoxController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/<ComboBox>
        public IHttpActionResult Gettests()
        {
            var test = _context.ComboBox.ToList();

            return Ok(test);
        }
    }
}
