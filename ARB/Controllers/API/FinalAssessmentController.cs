using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using ARB.Models;
using ARB.Dtos;
using AutoMapper;



namespace ARB.Controllers.API
{
    public class FinalAssessmentController : ApiController
    {
        private ApplicationDbContext _context;

        public FinalAssessmentController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/finalassessment


        public IHttpActionResult GetFinalAssessments()
        {
            var finalAssessmentDto = _context.FinalAssessments.Include(f => f.BiRads)
                .Include(f => f.Recommendation).ToList()
                .Select(Mapper.Map<FinalAssessment, FinalAssessmentDto>);
            return Ok(finalAssessmentDto);
        }

        //GET /api/finalassessment/1
        public IHttpActionResult GetFinalAssessment(int id)
        {
            var finalAssessment = _context.FinalAssessments.Include(f => f.BiRads)
                .Include(f => f.Recommendation).SingleOrDefault(f => f.Id == id);

            if (finalAssessment == null)
                return Ok(new FinalAssessment());

            return Ok(Mapper.Map<FinalAssessment, FinalAssessmentDto>(finalAssessment));
        }

        [HttpPost]
        public IHttpActionResult PostFinalAssessment(FinalAssessmentDto finalAssessmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var finalAssessment = Mapper.Map<FinalAssessmentDto, FinalAssessment>(finalAssessmentDto);
            _context.FinalAssessments.Add(finalAssessment);
            _context.SaveChanges();

            finalAssessmentDto.Id = finalAssessment.Id;
            return Created(new Uri(Request.RequestUri + "/" + finalAssessment.Id), finalAssessmentDto);
            //return Ok();
        }

        

        //PUT /api/finalassessment/1
        [HttpPut]
        public IHttpActionResult UpdateFianlAssessment([FromUri] int id, [FromBody] FinalAssessmentDto finalAssessmentDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var finalAssessmentInDb = _context.FinalAssessments.SingleOrDefault(f => f.Id == id);

            if (finalAssessmentInDb == null)
                return NotFound();

            Mapper.Map(finalAssessmentDto, finalAssessmentInDb);

            _context.SaveChanges();

            return Ok();
        }

        //DELETE /api/finalassessment/1
        [HttpDelete]
        public IHttpActionResult DeleteFinalAssessment(int id)
        {
            var finalAssessmentInDb = _context.FinalAssessments.SingleOrDefault(f => f.Id == id);

            if (finalAssessmentInDb == null)
                return NotFound();

            _context.FinalAssessments.Remove(finalAssessmentInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
