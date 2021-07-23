using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using ARB.Models;
using ARB.Dtos;


namespace ARB.Controllers.API
{
    [RoutePrefix("api/Doctor")]
    public class DoctorController : ApiController
    {
        private ApplicationDbContext _context;

        public DoctorController()
        {
            _context = new ApplicationDbContext();
        }
        public List<Patient> patients()
        {
            var patient = _context.Patients.ToList();
            /*.Include(p => p.ClinicalInfo)
            .Include(p => p.GeneralInfo)
            .Include(p => p.FinalAssessment)

            *//*  .Include(p => p.ExamData)*/

            return patient;
        }
        public List<ClinicalInfo> clinicalInfos()
        {
            var clinicalInfos = _context.ClinicalInfos
                                       .Include(c => c.Asymmetries)
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

        /*    [Route("doctor")]
            [HttpGet]*/

        // GET /api/doctor
        public IHttpActionResult Get()
        {
            var doctor = _context.Doctors.ToList();

            return Ok(doctor);
        }
        /*    [Route("doctor/{id}")]
            [HttpGet]*/
        // GET /api/doctor/1
        public IHttpActionResult Get(int id)
        {

            var doctor = _context.Doctors.SingleOrDefault(g => g.Id == id);
            if (doctor == null)
                return NotFound();

            var patientsOfThisDoctor = patients().Where(c => c.DoctorId == id).ToList();
            doctor.Patients = patientsOfThisDoctor;
            _context.SaveChanges();
            return Ok(doctor);
        }



        // POST /api/doctor
   /*     [Route("doctor")]*/
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


        [Route("LoginOfTheDoctor")]
        [HttpPost]
        public IHttpActionResult PostLogin(LoginViewModel loginViewModel)
        {
            var errors = ModelState
                        .Where(x => x.Value.Errors.Count > 0)
                        .Select(x => new { x.Key, x.Value.Errors })
                        .ToArray();

            if (!ModelState.IsValid)
                return Ok("Error");

            var doctor = _context.Doctors.SingleOrDefault(d => d.Email == loginViewModel.Email);
            if (doctor == null)
            {
                return Ok<string>("Not Found");

            }
            if (doctor.Password != loginViewModel.Password)
            {
                return Ok<string>("Wrong password");
            }
            return Created(new Uri(Request.RequestUri + "/" + doctor.Id), doctor);
        }


        // PUT /api/doctor/1
        [HttpPut]
        public IHttpActionResult Put(int id, DoctorDto doctorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var doctorInDb = _context.Doctors.SingleOrDefault(g => g.Id == id);

            if (doctorInDb == null)
                return NotFound();

            _context.Entry(doctorInDb).CurrentValues.SetValues(doctorDto);
            _context.SaveChanges();

            return Ok(doctorInDb);
        }

        // DELETE /api/doctor/1
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



