using ARB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ARB.Controllers.API
{
    public class LoginController : ApiController
    {
        private ApplicationDbContext _context;


        public LoginController()
        {
            _context = new ApplicationDbContext();

        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        // POST api/<controller>
        public void Post([FromBody] AspNet)
        {
              /*  DemologinEntities DB = new DemologinEntities();
                var Obj = DB.Usp_Login(Lg.UserName, Lg.Password).ToList<Usp_Login_Result>().FirstOrDefault();
                if (Obj.Status == 0)
                    return new Response { Status = "Invalid", Message = "Invalid User." };
                if (Obj.Status == -1)
                    return new Response { Status = "Inactive", Message = "User Inactive." };
                else
                    return new Response { Status = "Success", Message = Lg.UserName };*/



        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}