﻿using System;
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

namespace ARB.Controllers.API
{

    [RoutePrefix("api/patient")]
    public class PatientController : ApiController
    {
        private ApplicationDbContext _context;


        public PatientController()
        {
            _context = new ApplicationDbContext();


        }
        public List<Patient> patients() {
            var patient = _context.Patients
                                .Include(p => p.ClinicalInfo)
                                .Include(p => p.GeneralInfo)
                                .Include(p => p.FinalAssessment)
                                /*  .Include(p => p.ExamData)*/
                                .ToList();
            return patient;
        }
        public List<ClinicalInfo> clinicalInfos()
        {
            var clinicalInfos = _context.ClinicalInfos
                                       .Include(c => c.Asymmetries)
                                       /* .Include(c => c.ClockFace)
                                        .Include(c => c.MassMargin)
                                        .Include(c => c.MassDensity)
                                        .Include(c => c.Quadrant)*/
                                       .Include(c => c.SuspiciousMorphology)
                                       .Include(c => c.TypicallyBenign)
                                       .Include(c => c.Features)
                                       .Include(c => c.Distribution)
                                       .Include(c => c.MassSpecifications)
                                       .ToList();
            return clinicalInfos;
        }

        public List<FinalAssessment> finalAssessments() {
            return (_context.FinalAssessments
                .Include(f => f.BiRads)
                .Include(f => f.Recommendation).ToList());
        }


        // GET api/<controller>
        [Route("")]
        [HttpGet]
        public IHttpActionResult Get()
        {


            var patient = patients();

            foreach (var p in patients())
            {

                p.ClinicalInfo = clinicalInfos().SingleOrDefault(c => c.Id == p.ClinicalInfoId);
                p.GeneralInfo = _context.GeneralInfos.SingleOrDefault(c => c.Id == p.GeneralInfoId);
                p.FinalAssessment = finalAssessments().SingleOrDefault(c => c.Id == p.FinalAssessmentId);

                /*      p.ExamData = _context.ExamDatas.SingleOrDefault(c => c.Id == p.ExamDataId);*/

            };

            return Ok(patient);
        }


        // GET api/<controller>/5
        [Route("{id}/{by}")]
        [HttpGet]
        public IHttpActionResult Get(int id , string by)
        {
            Patient patient = new Patient();

            if (by == "\"examId\"")
            {
                patient = patients().SingleOrDefault(p => p.ExamDataId == id);


            }
            else
            {
                patient = patients().SingleOrDefault(p => p.Id == id);

            }
        
           
            if (patient == null)
                return NotFound();

            patient.ClinicalInfo = clinicalInfos().SingleOrDefault(c => c.Id == patient.ClinicalInfoId);
            patient.GeneralInfo = _context.GeneralInfos.SingleOrDefault(c => c.Id == patient.GeneralInfoId);
            patient.FinalAssessment = finalAssessments().SingleOrDefault(c => c.Id == patient.FinalAssessmentId);
            /*            patient.ExamData = _context.ExamDatas.SingleOrDefault(c => c.Id == patient.ExamDataId);*/
            patient.ClinicalInfo.MassSpecifications = _context.MassSpecifications.Where(c => c.ClinicalInfoId == patient.ClinicalInfoId)
                                                                                 .Include(c => c.ClockFace)
                                                                                 .Include(c => c.MassDensity)
                                                                                 .Include(c => c.MassMargin)
                                                                                 .Include(c => c.Quadrant).ToList();

          

            return Ok(Mapper.Map<Patient, PatientDto>(patient));
        }

       

      


        // POST api/<controller>


        [Route("")]
        [HttpPost]

        public IHttpActionResult Post([FromBody] Patient patient)
        {
            var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();

            if (!ModelState.IsValid)
                return Ok(errors);
            ExamData examData = _context.ExamDatas.SingleOrDefault(c => c.Id == patient.ExamDataId);
            if (examData == null)
            {
                return Ok("use Put Request");

            }
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + patient.Id), patient);


        }



        // PUT api/<controller>/5
        [Route("{id}")]
        [HttpPut]
      
        public IHttpActionResult Put([FromUri] int id, [FromBody] Patient patient)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patientInDb = patients().Single(g => g.Id == id);
          
            if (patientInDb == null)
                return NotFound();

            Mapper.Map(patient, patientInDb);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<controller>/5
        [Route("{id}")]
        [HttpDelete]

        public IHttpActionResult Delete(int id)
        {
            var patientInDb = _context.Patients.SingleOrDefault(g => g.Id == id);
            var clincalinfoInDb = _context.ClinicalInfos.SingleOrDefault(c => c.Id== patientInDb.ClinicalInfoId);
            var featuresInDb = _context.Features.SingleOrDefault(c => c.Id == clincalinfoInDb.FeatureId);
            var GeneralInfoInDb = _context.GeneralInfos.SingleOrDefault(c => c.Id== patientInDb.GeneralInfoId);
            var FinalAssesmentInDb = _context.FinalAssessments.SingleOrDefault(f => f.Id == patientInDb.FinalAssessmentId);
            var RecommendationInDb = _context.Recommendations.SingleOrDefault(r => r.Id == FinalAssesmentInDb.RecommendationId);
            
            if (patientInDb == null)
                return NotFound();
          
            
            _context.Features.Remove(featuresInDb);
            _context.ClinicalInfos.Remove(clincalinfoInDb);
            _context.GeneralInfos.Remove(GeneralInfoInDb);
            _context.Recommendations.Remove(RecommendationInDb);
            _context.FinalAssessments.Remove(FinalAssesmentInDb);
            _context.Patients.Remove(patientInDb);
            _context.SaveChanges();

            return Ok(patientInDb);
        }
    }
}
