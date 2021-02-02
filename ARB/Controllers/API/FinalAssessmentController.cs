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
    public class FinalAssessmentController : ApiController
    {
        private ApplicationDbContext _context;

        public FinalAssessmentController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult TakingData(FinalAssessmentDto finalAssessmentDto)
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
    }
}
