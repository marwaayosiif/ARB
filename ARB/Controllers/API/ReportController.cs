using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using ARB.Models;
using ARB.Dtos;
using DnsClient;
using ARB.Controllers.API;
using Newtonsoft.Json;
using System.Text;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using System.Web;

namespace ARB.Controllers.API
{
    [RoutePrefix("api/Report")]
    /*   [EnableCors(origins: "https://marwaayosiif.github.io", headers: "*", methods: "*")] */
 [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ReportController : ApiController
    {
        private ApplicationDbContext _context;


        public ReportController()
        {
            _context = new ApplicationDbContext();

        }
        // GET api/<controller>
        public  IEnumerable<Report> Get()
        {
          
            return (_context.Report.ToList());
        }

        [Route("{id}")]
        [HttpGet]
     
        // GET api/<controller>/5
        public IHttpActionResult GetAll(int id)
        {
            if (id.GetType() == typeof(string))
            {
                return Ok("Error");
            }
            var name = id.ToString();
            var Report = _context.Report.FirstOrDefault(c => c.Name == name);
            if(Report == null)
            {
                return Ok("Not Found");
            }
            return Ok(Report.TileImage);
        }
        [HttpPost]
        // PUT api/<controller>/5
        public HttpResponseMessage PostBlog()
        {
            var newReport = new Report();

            var httpRequest = HttpContext.Current.Request;

            var postedFile = httpRequest.Files["Image"];


            if (postedFile != null)
            {
                newReport.TileImage = new Byte[postedFile.ContentLength];

                postedFile.InputStream.Read(newReport.TileImage, 0, postedFile.ContentLength);
                
                newReport.Name = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(100).ToArray()).Replace(" ", "-");

                _context.Report.Add(newReport);

                _context.SaveChanges();


            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
            
        }
       
        public IHttpActionResult Put(string id, [FromBody] Report report)
        {
            var reportInDb = _context.Report.SingleOrDefault(c => c.Name == id);

            if (reportInDb == null)
            {
                return NotFound();
            }
            else 
            {
                _context.Entry(reportInDb).CurrentValues.SetValues(report);

            }
            return Ok(report.TileImage);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}