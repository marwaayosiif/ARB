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
    [RoutePrefix("api/ClinicalInfo")]
    public class ClinicalInfoController : ApiController
    {
        private ApplicationDbContext _context;

       
        public ClinicalInfoController()
        {
            _context = new ApplicationDbContext();
             
        }
       
        public List<MassSpecification> massSpecifications()
        {
            var massSpecifications = _context.MassSpecifications
                                        .Include(c => c.ClockFace)
                                        .Include(c => c.MassMargin)
                                        .Include(c => c.MassDensity)
                                        .Include(c => c.Quadrant)
                                       .ToList();
            return massSpecifications;
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
        [Route("")]
        [HttpGet]
        // GET api/<controller>
        public IHttpActionResult GetClinicalInfo()
        {

            var clinicalInfoDtos = clinicalInfos();

            return Ok(clinicalInfoDtos);

        }

        // GET api/<controller>/5-
        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var clinicalInfo = clinicalInfos().SingleOrDefault(c => c.Id == id);
            if (clinicalInfo == null)
            {
                var newClinicalInfo = new ClinicalInfo();
                newClinicalInfo.Features = new Features();
     
                return Ok(new ClinicalInfo());
            }

            var massSpecification = massSpecifications().Where(ms => ms.ClinicalInfoId == id).ToList();
            clinicalInfo.MassSpecifications = massSpecification;
            clinicalInfo.FeatureId = id;
            return Ok(clinicalInfo);
        }




        // POST api/<controller>
        [Route("")]
        [HttpPost]

        public IHttpActionResult Post([FromBody] ClinicalInfoDto clinicalInfoDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();
            var clinicalInfo = Mapper.Map<ClinicalInfoDto, ClinicalInfo>(clinicalInfoDto);
            var massSpecification = clinicalInfoDto.MassSpecifications.ToList();
            foreach (var mass in massSpecification)
            {
                mass.Id = clinicalInfoDto.Id;
                _context.MassSpecifications.Add(mass);
 
            }
          
            _context.ClinicalInfos.Add(clinicalInfo);
            _context.SaveChanges();
            clinicalInfo.Id = clinicalInfoDto.Id;
            return Created(new Uri(Request.RequestUri + "/" + clinicalInfo.Id), clinicalInfoDto);
        }
        [Route("{id}")]
        [HttpPut]
        // PUT api/<controller>/5
        public void Put([FromUri] int id, [FromBody] ClinicalInfoDto clinicalInfoDto)
        {
            var clinicalInfoDb = _context.ClinicalInfos.SingleOrDefault(c => c.Id == id);

            if (clinicalInfoDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            /*    clinicalInfoDb.AsymmetriesId = clinicalInfoDto.AsymmetriesId;
                clinicalInfoDb.BreastCompostion = clinicalInfoDto.BreastCompostion;

                clinicalInfoDb.FeatureId = clinicalInfoDto.FeatureId;
                clinicalInfoDb.DistributionId = clinicalInfoDto.DistributionId;

                clinicalInfoDb.NumOfMass = clinicalInfoDto.NumOfMass;
                clinicalInfoDb.SuspiciousMorphologyId = clinicalInfoDto.SuspiciousMorphologyId;
                clinicalInfoDb.TypicallyBenignId = clinicalInfoDto.TypicallyBenignId;*/
            Mapper.Map(clinicalInfoDto, clinicalInfoDb);

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

