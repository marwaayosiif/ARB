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
    public class ClinicalInfoController : ApiController
    {
        private ApplicationDbContext _context;

        public ClinicalInfoController()
        {
            _context = new ApplicationDbContext();
        }
        // GET api/<controller>
        public IHttpActionResult GetClinicalInfo()
        {
     
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
            return Ok(clinicalInfoDtos);

        }

        // GET api/<controller>/5-
        public IHttpActionResult Get(int id)
        {
            var clinicalInfo = _context.ClinicalInfos
                .Include(c => c.Asymmetries)
                .Include(c => c.ClockFace)
                .Include(c => c.MassMargin)
                .Include(c => c.MassDensity)
                .Include(c => c.Quadrant)
                .Include(c => c.SuspiciousMorphology)
                .Include(c => c.TypicallyBenign)
                .ToList().SingleOrDefault(c => c.Id == id);
            if (clinicalInfo == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<ClinicalInfo, ClinicalInfoDto>(clinicalInfo));
        }

        // POST api/<controller>
        [HttpPost]
        public IHttpActionResult CreateCustomer(ClinicalInfoDto clinicalInfoDto)
        {
            if (!ModelState.IsValid)
                /*throw new HttpResponseException(HttpStatusCode.BadRequest);*/
                return BadRequest();

            var clinicalInfo = Mapper.Map<ClinicalInfoDto, ClinicalInfo>(clinicalInfoDto);
            _context.ClinicalInfos.Add(clinicalInfo);
            _context.SaveChanges();
            clinicalInfo.Id = clinicalInfoDto.Id;
            return Created(new Uri(Request.RequestUri + "/" + clinicalInfo.Id), clinicalInfoDto);
        }

        [HttpPut]
        // PUT api/<controller>/5
        public void Put(int id, ClinicalInfoDto clinicalInfoDto)
        {
            var clinicalInfoDb = _context.ClinicalInfos.SingleOrDefault(c => c.Id == id);

            if (clinicalInfoDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            Mapper.Map(clinicalInfoDto, clinicalInfoDto);

            _context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            var clinicalInfoInDb = _context.ClinicalInfos.SingleOrDefault(c => c.Id == id);
         
            var featuresInDb = _context.Features.SingleOrDefault(c => c.Id == clinicalInfoInDb.FeatureId);
          
            _context.ClinicalInfos.Remove(clinicalInfoInDb);
            _context.Features.Remove(featuresInDb);           
            _context.SaveChanges();
        }
    }
}