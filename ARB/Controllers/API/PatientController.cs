using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ARB.Models;
using ARB.Dtos;
using AutoMapper;

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
            var patient = _context.Patients.ToList().Select(Mapper.Map<Patient, PatientDto>);

            return Ok(patient);
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            var patient = _context.Patients.SingleOrDefault(p => p.Id == id);

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

            patient.Id = patient.Id;
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

            Mapper.Map(patientDto, patientInDb);

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

            if (patientInDb == null)
                return NotFound();
          
            
            _context.Features.Remove(featuresInDb);
            _context.ClinicalInfos.Remove(clincalinfoInDb);
            _context.Patients.Remove(patientInDb);

            _context.SaveChanges();

            return Ok();
        }
    }
}