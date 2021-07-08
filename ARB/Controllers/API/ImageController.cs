
using ARB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ARB.Controllers.API
{
    public class ImageController : ApiController
    {
        private ApplicationDbContext _context;

        public ImageController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        [Route("api/UploadImage")]
        
        public HttpResponseMessage UploadImage()
        {
            string imageName = null;
            var httpRequest = HttpContext.Current.Request;
            var postedFile = httpRequest.Files["Image"];
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(10).ToArray()).Replace(" ", "-");
            imageName = imageName + Path.GetExtension(postedFile.FileName);
            var filePath = HttpContext.Current.Server.MapPath("~/Images/" + imageName);
            postedFile.SaveAs(filePath);

            Image image = new Image()
            {
                ImageName = imageName,
                FILEPATHNAME = filePath,
            };
            _context.Image.Add(image);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);

        }
        [HttpGet]
        public IHttpActionResult GetImages(int id)
        {
            var images = _context.Image.SingleOrDefault(g => g.Id == id);
            if (images == null)
                return NotFound();

            return Ok(images.FILEPATHNAME);
        }

        [HttpDelete]
        public IHttpActionResult DeleteImage(string name)
        {
            var imageInDb = _context.Image.SingleOrDefault(g => g.FILEPATHNAME == name);

            if (imageInDb == null)
                return NotFound();

            _context.Image.Remove(imageInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
