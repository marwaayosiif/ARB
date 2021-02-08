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

namespace ARB.Controllers.API
{
    public class ExamDataController : ApiController
    {
        private ApplicationDbContext _context;

        public ExamDataController()
        {
            _context = new ApplicationDbContext();

        }

        // GET api/<controller>
        public IHttpActionResult Get()
        {
            return Ok(_context.ExamDatas.ToList());
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            return Ok(_context.ExamDatas.ToList().SingleOrDefault(c=>c.Id==id));
        }

        // POST api/<controller>
        public IHttpActionResult Post(ExamData examData)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.ExamDatas.Add(examData);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + examData.Id), examData);
        }

        // PUT api/<controller>/5
        public void Put(int id, ExamData examData)
        {
            var examDataInDb = _context.ExamDatas.SingleOrDefault(e => e.Id == id );
            if (examDataInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            examDataInDb.Name = examData.Name;
            examDataInDb.PatientID = examData.PatientID;
            examDataInDb.ReferringDoctor = examData.ReferringDoctor;
            examDataInDb.StudyDate = examData.StudyDate;
            examDataInDb.LastOperation = examData.LastOperation;
            _context.SaveChanges();

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var examDataInDb = _context.ExamDatas.SingleOrDefault(e => e.Id == id);
            _context.ExamDatas.Remove(examDataInDb);
            _context.SaveChanges();

        }
    }
}