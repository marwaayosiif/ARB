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
   
    public class DoctorController : ApiController
    {
        private ApplicationDbContext _context;

        public DoctorController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/generalinfo
        public IHttpActionResult Get()
        {
            var doctorDtos = _context.Doctors.ToList().Select(Mapper.Map<Doctor, DoctorDto>);

            return Ok(doctorDtos);
        }

        // GET /api/generalinfo/1
        public IHttpActionResult GetGeneralInfo(int id)
        {
            var doctor = _context.Doctors.SingleOrDefault(g => g.Id == id);

            if (doctor == null)
                return NotFound();

            return Ok(Mapper.Map<Doctor, DoctorDto>(doctor));
        }
        // POST /api/generalinfo
        [HttpPost]
        public IHttpActionResult PostGeneralInfo(DoctorDto doctorDto)
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