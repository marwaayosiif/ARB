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

namespace ARB.Controllers.API
{
   
    public class DoctorController : ApiController
    {
        private ApplicationDbContext _context;

        public DoctorController()
        {
            _context = new ApplicationDbContext();
        }
        public List<Patient> patients()
        {
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
                                       .Include(c => c.ClockFace)
                                       .Include(c => c.MassMargin)
                                       .Include(c => c.MassDensity)
                                       .Include(c => c.Quadrant)
                                       .Include(c => c.SuspiciousMorphology)
                                       .Include(c => c.TypicallyBenign)
                                       .Include(c => c.Features)
                                       .Include(c => c.Distribution)
                                       .ToList();
            return clinicalInfos;
        }

        public List<FinalAssessment> finalAssessments()
        {
            return (_context.FinalAssessments
                .Include(f => f.BiRads)
                .Include(f => f.Recommendation).ToList());
        }



        // GET /api/generalinfo
        public IHttpActionResult Get()
        {
            var doctor = _context.Doctors.Include(c => c.Patients);
               
            var patientsOfThisDoctor = patients().GroupBy(x => x.DoctorId).ToList();

            doctor.p = patientsOfThisDoctor;
            return Ok(patientsOfThisDoctor);
        }

        // GET /api/generalinfo/1
        public IHttpActionResult Get(int id)
        {
            

            var doctor = _context.Doctors.Include(c=>c.Patients).SingleOrDefault(g => g.Id == id);
            var patientsOfThisDoctor = patients().Where(c => c.DoctorId == id).ToList();
           

            if (doctor == null)
                return NotFound();

            doctor.Patients = patientsOfThisDoctor;
           /* doctor.PatientsId = patientsOfThisDoctor.ForEach(d => d.Id);*/
            _context.SaveChanges();
            return Ok(doctor);
        }

       

        // POST /api/generalinfo
        [HttpPost]
        public IHttpActionResult Post(DoctorDto doctorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var doctor = Mapper.Map<DoctorDto, Doctor>(doctorDto);
            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            doctorDto.Id = doctor.Id;
            return Created(new Uri(Request.RequestUri + "/" + doctor.Id), doctorDto);
        }

        // PUT /api/generalinfo/1
        [HttpPut]
        public IHttpActionResult Put(int id, DoctorDto doctorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var doctorInDb = _context.Doctors.SingleOrDefault(g => g.Id == id);

            if (doctorInDb == null)
                return NotFound();

            Mapper.Map(doctorDto, doctorInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/generalinfo/1
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var doctorInDb = _context.Doctors.SingleOrDefault(g => g.Id == id);

            if (doctorInDb == null)
                return NotFound();

            _context.Doctors.Remove(doctorInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}