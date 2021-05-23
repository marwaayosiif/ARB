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

        // GET /api/generalinfo
        public IHttpActionResult GetGeneralInfos()
        {
            var generalInfoDto = _context.GeneralInfos.ToList().Select(Mapper.Map<GeneralInfo, GeneralInfoDto>);

            return Ok(generalInfoDto);
        }

        // GET /api/generalinfo/1
        public IHttpActionResult GetGeneralInfo(int id)
        {
            var generalInfo = _context.GeneralInfos.SingleOrDefault(g => g.Id == id);

            if (generalInfo == null)
                return Ok(new GeneralInfo());

            return Ok(Mapper.Map<GeneralInfo, GeneralInfoDto>(generalInfo));
        }
        // POST /api/generalinfo
        [HttpPost]
        public IHttpActionResult PostGeneralInfo(GeneralInfo generalInfo)
        {
            var errors = ModelState
                       .Where(x => x.Value.Errors.Count > 0)
                       .Select(x => new { x.Key, x.Value.Errors })
                       .ToArray();

            if (!ModelState.IsValid)
                return Ok(errors);


            /*var generalInfo = Mapper.Map<GeneralInfoDto, GeneralInfo>(generalInfoDto);*/
            _context.GeneralInfos.Add(generalInfo);
            _context.SaveChanges();

         /*   generalInfoDto.Id = generalInfo.Id;*/
            return Created(new Uri(Request.RequestUri + "/" + generalInfo.Id), generalInfo);
            //return Ok();
        }

        // PUT /api/generalinfo/1
        [HttpPut]
        public IHttpActionResult UpdateGeneralInfo(int id, GeneralInfoDto generalInfoDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var generalInfoInDb = _context.GeneralInfos.SingleOrDefault(g => g.Id == id);

            if (generalInfoInDb == null)
                return NotFound();
      
            Mapper.Map(generalInfoDto, generalInfoInDb);

            _context.SaveChanges();

            return Ok(generalInfoInDb);
        }

        // DELETE /api/generalinfo/1
        [HttpDelete]
        public IHttpActionResult DeleteGeneralInfo(int id)
        {
            var generalInfoInDb = _context.GeneralInfos.SingleOrDefault(g => g.Id == id);

            if (generalInfoInDb == null)
                return NotFound();

            _context.GeneralInfos.Remove(generalInfoInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}

