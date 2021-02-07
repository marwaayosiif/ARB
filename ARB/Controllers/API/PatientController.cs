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
    public class PatientController : ApiController
    {
        private ApplicationDbContext _context;

        public PatientController()
        {
            _context = new ApplicationDbContext();
        }

        // GET api/<controller>

        public IHttpActionResult Get()
        {

            var patient = _context.Patients
                .ToList()
                .Select(Mapper.Map<Patient, PatientDto>);

            var clinicalInfoDtos = _context.ClinicalInfos
                                            .Include(c => c.Asymmetries)
                                            .Include(c => c.ClockFace)
                                            .Include(c => c.MassMargin)
                                            .Include(c => c.MassDensity)
                                            .Include(c => c.Quadrant)
                                            .Include(c => c.SuspiciousMorphology)
                                            .Include(c => c.TypicallyBenign)
                                            .ToList()
                                            .Select(Mapper.Map<ClinicalInfo, ClinicalInfoDto>);

            var finalAssessmentDto = _context.FinalAssessments
                                            .Include(f => f.BiRads)
                                            .Include(f => f.Recommendation).ToList()
                                            .Select(Mapper.Map<FinalAssessment, FinalAssessmentDto>);

            foreach (var p in patient)
            {

                p.ClinicalInfo = clinicalInfoDtos.SingleOrDefault(c => c.Id == p.ClinicalInfoId);
                p.GeneralInfo = _context.GeneralInfos.SingleOrDefault(c => c.Id == p.GeneralInfoId);
                p.FinalAssessment = finalAssessmentDto.SingleOrDefault(c => c.Id == p.FinalAssessmentId);
               
            };

            return Ok(patient);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var patient = _context.Patients
                    .Include(p=>p.ClinicalInfo)
                    .Include(p=>p.GeneralInfo)
                    .Include(p=>p.FinalAssessment)
                    .SingleOrDefault(p => p.Id == id);

            if (patient == null)
                return NotFound();

            return Ok(Mapper.Map<Patient, PatientDto>(patient));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult Post(PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patient = Mapper.Map<PatientDto, Patient>(patientDto);
            _context.Patients.Add(patient);
            _context.SaveChanges();

            patientDto.Id = patient.Id;
            return Created(new Uri(Request.RequestUri + "/" + patient.Id), patientDto);
            //return Ok();
        }


        // PUT api/<controller>/5
        [HttpPut]
        public IHttpActionResult Put(int id, PatientDto patientDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var patientInDb = _context.Patients.SingleOrDefault(g => g.Id == id);

            if (patientInDb == null)
                return NotFound();

            patientInDb.Name = patientDto.Name;
            patientInDb.ClinicalInfoId = patientDto.ClinicalInfoId;
            patientInDb.FinalAssessmentId = patientDto.FinalAssessmentId;
            patientInDb.GeneralInfoId = patientDto.GeneralInfoId;
            patientInDb.BirthDate = patientDto.BirthDate;
            patientInDb.Modality = patientDto.Modality;
            patientInDb.Status = patientDto.Status;
            _context.SaveChanges();

            return Ok();
        }

        // DELETE api/<controller>/5
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

            return Ok();
        }
    }
}
