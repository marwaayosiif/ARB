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

namespace ARB.Controllers.API
{
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

        // GET api/<controller>/5
        public IHttpActionResult Get(string name)
        {
            var Report = _context.Report.SingleOrDefault(c => c.Name == name);
            if(Report == null)
            {
                return NotFound();
            }
            return Ok(Report.TileImage);
        }

        // PUT api/<controller>/5
        public IHttpActionResult PostBlog(Report report)
        {


            if (report != null)
            {
                var newReport = new Report
                {
                    Name = report.Name,
                    TileImage = report.TileImage
                };
                _context.Report.Add(newReport);
                _context.SaveChanges();

            }
            else
            {
                return BadRequest();
            }
            return Ok(report);
            
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