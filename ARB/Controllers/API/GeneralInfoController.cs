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
    public class GeneralInfoController : ApiController
    {
        private ApplicationDbContext _context;

        public GeneralInfoController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult TakingData(GeneralInfoDto generalInfoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var generalInfo = Mapper.Map<GeneralInfoDto, GeneralInfo>(generalInfoDto);
            _context.GeneralInfos.Add(generalInfo);
            _context.SaveChanges();

            generalInfoDto.Id = generalInfo.Id;
            return Created(new Uri(Request.RequestUri + "/" + generalInfo.Id), generalInfoDto);
            //return Ok();
        }
    }
}

