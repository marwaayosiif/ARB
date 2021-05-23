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
    [RoutePrefix("api/examData")]
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
        
        [Route("ExamDataOfDoctor/{doctorId}")]

        [HttpGet]
        public IHttpActionResult ExamDataOfDoctor(int doctorId)
        {
            var examDatas = _context.ExamDatas.ToList().Where(c => c.DoctorId == doctorId);
            if (examDatas == null)
                return NotFound();


            return Ok(examDatas);
        }

        [Route("{Id}")]
        [HttpGet]

        public IHttpActionResult Get(int id)
        {
            return Ok(_context.ExamDatas.ToList().SingleOrDefault(c => c.Id == id));
        }
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult Post(ExamData examData)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            _context.ExamDatas.Add(examData);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + examData.Id), examData);
        }
         [Route("{id}")]
        [HttpPut]

        // PUT api/<controller>/5
        public void Put([FromUri] int id, [FromBody] ExamDataDto examDataDto)
        {
            
            var examDataInDb = _context.ExamDatas.SingleOrDefault(e => e.Id == id );
            if (examDataInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(examDataDto, examDataInDb);

            _context.SaveChanges();

        }
        [Route("{id}")]
        [HttpDelete]

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var examDataInDb = _context.ExamDatas.SingleOrDefault(e => e.Id == id);
            var patientInDb = _context.Patients.SingleOrDefault(g => g.ExamDataId == id);
            
            if (examDataInDb == null )
                return NotFound();
            if(patientInDb != null)
            {
                var clincalinfoInDb = _context.ClinicalInfos.SingleOrDefault(c => c.Id == patientInDb.ClinicalInfoId);
                var featuresInDb = _context.Features.SingleOrDefault(c => c.Id == clincalinfoInDb.FeatureId);
                var GeneralInfoInDb = _context.GeneralInfos.SingleOrDefault(c => c.Id == patientInDb.GeneralInfoId);
                var FinalAssesmentInDb = _context.FinalAssessments.SingleOrDefault(f => f.Id == patientInDb.FinalAssessmentId);
                var RecommendationInDb = _context.Recommendations.SingleOrDefault(r => r.Id == FinalAssesmentInDb.RecommendationId);

                _context.Features.Remove(featuresInDb);
                _context.ClinicalInfos.Remove(clincalinfoInDb);
                _context.GeneralInfos.Remove(GeneralInfoInDb);
                _context.Recommendations.Remove(RecommendationInDb);
                _context.FinalAssessments.Remove(FinalAssesmentInDb);
                _context.Patients.Remove(patientInDb);
            }

               
            _context.ExamDatas.Remove(examDataInDb);
            _context.SaveChanges();

            return Ok(examDataInDb);

        }
    }
}