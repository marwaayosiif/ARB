using ARB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var test = _context.test.Include(t => t.ComboBox).ToList();
            

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

        [HttpPut]
        public IHttpActionResult Updatetest(int id, test TEST)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var testInDb = _context.test.SingleOrDefault(g => g.Id == id);
             
            if (testInDb == null)
                return NotFound();
            else
                testInDb.Name = TEST.Name;
                testInDb.Number = TEST.Number;
                testInDb.Checkbox = TEST.Checkbox;
            testInDb.ComboBoxId = TEST.ComboBoxId;
            testInDb.Radio = TEST.Radio;
            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/generalinfo/1
        [HttpDelete]
        public IHttpActionResult Deletetest(int id)
        {
            var testInDb = _context.test.SingleOrDefault(g => g.Id == id);

            if (testInDb == null)
                return NotFound();

            _context.test.Remove(testInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}