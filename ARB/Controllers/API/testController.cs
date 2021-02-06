using ARB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ARB.Controllers.API
{
    public class testController : ApiController
    {

        private ApplicationDbContext _context;

        public testController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/<controller>
        public IHttpActionResult Gettests()
        {
            var test = _context.test.ToList();

            return Ok(test);
        }

        
        // GET /api/generalinfo/1
        public IHttpActionResult Gettest(int id)
        {
            var test = _context.test.SingleOrDefault(g => g.Id == id);

            if (test == null)
                return NotFound();

            return Ok(test);
        }



        
        // POST /api/generalinfo
        [HttpPost]
        public IHttpActionResult Posttest(test test)
        {
            if (!ModelState.IsValid)
                return BadRequest();

           
            _context.test.Add(test);
            _context.SaveChanges();

           
            return Created(new Uri(Request.RequestUri + "/" + test.Id), test);
            //return Ok();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}