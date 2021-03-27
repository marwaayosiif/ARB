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
    [RoutePrefix("api")]
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


        [Route("ClinicalInfo")]

        [HttpGet]
        // GET api/<controller>
        public IHttpActionResult GetClinicalInfo()
        {

            var clinicalInfoDtos = clinicalInfos();
                           
            return Ok(clinicalInfoDtos);

        }

        // GET api/<controller>/5-
        public IHttpActionResult Get(int id)
        {
            var clinicalInfo = clinicalInfos().SingleOrDefault(c => c.Id == id);
            if (clinicalInfo == null)
            {
                return NotFound();
            }

            var massSpecification = massSpecifications().Where(ms => ms.ClinicalInfoId == id).ToList();
            clinicalInfo.MassSpecifications = massSpecification;
            clinicalInfo.FeatureId = id;
            return Ok(Mapper.Map<ClinicalInfo, ClinicalInfoDto>(clinicalInfo));
        }

        // POST api/<controller>
        [Route("ClinicalInfo")]
        [HttpPost]

        public IHttpActionResult CreateClinicalInfo(ClinicalInfoDto clinicalInfoDto)
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

        [HttpPut]
        // PUT api/<controller>/5
        public void Put(int id, ClinicalInfoDto clinicalInfoDto)
        {
            var clinicalInfoDb = _context.ClinicalInfos.SingleOrDefault(c => c.Id == id);

            if (clinicalInfoDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            clinicalInfoDb.AsymmetriesId = clinicalInfoDto.AsyId;
            clinicalInfoDb.BreastCompostion = clinicalInfoDto.BreastCompostion;
          
            clinicalInfoDb.FeatureId = clinicalInfoDto.FeatureId;
            clinicalInfoDb.DistributionId = clinicalInfoDto.DistributionId;
 
            clinicalInfoDb.NumOfMass = clinicalInfoDto.NumOfMass;
            clinicalInfoDb.SuspiciousMorphologyId = clinicalInfoDto.SuspiciousMorphologyId;
            clinicalInfoDb.TypicallyBenignId = clinicalInfoDto.TypicallyBenignId;
            /*clinicalInfoDb.ClockFaceId = clinicalInfoDto.ClockFaceId;
            clinicalInfoDb.Depth = clinicalInfoDto.Depth;
            clinicalInfoDb.DistanceFromTheNipple = clinicalInfoDto.DistanceFromTheNipple;
            clinicalInfoDb.QuadrantId = clinicalInfoDto.QuadrantId;
            clinicalInfoDb.Laterality = clinicalInfoDto.Laterality;
            clinicalInfoDb.MassDensityId = clinicalInfoDto.MassDensityId;
            clinicalInfoDb.MassMarginId = clinicalInfoDto.MassMarginId;
            clinicalInfoDb.MassShape = clinicalInfoDto.MassShape;
                */
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

