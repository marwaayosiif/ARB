using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ARB.Models;

namespace ARB.Controllers.API
{
    public class ImagesController : ApiController
    {
        private ApplicationDbContext _context;

        public ImagesController()
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

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Image imageFromUser)
        {
            var imageDB = imageFromUser;
            var name = imageDB.ImageName;
            //var httpRequest = HttpContext.Current.Request;
            //var postedFile = httpRequest.Files["Image"];
            //imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            //imageName = imageName + Path.GetExtension(postedFile.FileName);
            //var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);

            var imageName = new String(name.Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + Path.GetExtension(name);
            
            var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
            //postedFile.SaveAs(filePath);
            System.Diagnostics.Debug.WriteLine("Image");
            System.Diagnostics.Debug.WriteLine(imageDB.ImageName);
            System.Diagnostics.Debug.WriteLine(filePath);
            Image image = new Image()
            {
                ImageName = imageName
               /* FILEPATHNAME = filePath,*/
          /*      PatientId = 1*/
            };
            _context.Image.Add(image);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + image.Id), image);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}