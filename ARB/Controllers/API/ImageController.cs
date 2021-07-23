
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
using Newtonsoft.Json;
using System.Web.Http.Cors;

namespace ARB.Controllers.API
{
    [RoutePrefix("api/Image")]
    [EnableCors(origins: "https://marwaayosiif.github.io", headers: "*", methods: "*")] 
    //[EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
    public class ImageController : ApiController
    {
        private ApplicationDbContext _context;

        public ImageController()
        {
            _context = new ApplicationDbContext();
        }
       
        [HttpPost]
        
        public HttpResponseMessage UploadImage()
        {
            string imageName = null;
           
            var image = new Image() ;
            
            var httpRequest = HttpContext.Current.Request;
            
            var postedFile = httpRequest.Files["Image"];

            
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(100).ToArray()).Replace(" ", "-");

       /*     image.PatientId = imageName.Split('_')[1];*/
            
            /*imageName = imageName + Path.GetExtension(postedFile.FileName);*/

            if (postedFile == null)
            {
                
                return Request.CreateResponse(HttpStatusCode.NoContent);
                
            }

            image.data = new Byte[postedFile.ContentLength];
           
            postedFile.InputStream.Read(image.data, 0, postedFile.ContentLength);
            
            image.ImageName = imageName;


            image.FileLength = postedFile.ContentLength;

            _context.Image.Add(image);

            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created, Convert.ToBase64String(image.data, 0, postedFile.ContentLength));

        }
 
        [Route("{id}")]
        [HttpGet]
      
        public IHttpActionResult GetImages(int id)
        {
            string patientID = id.ToString();
            
            var images = _context.Image.Where(g => g.ImageName == patientID).Select(c=>new {c.data}).ToList();

           
            
            if (images == null)
                return NotFound();
    
            var allImages = new List<Byte[]>();

            foreach (var image in images)
            {
               
                allImages.Add(image.data);
               
            }
            
           

            return Ok(allImages);
        }

        [Route("{Id}/{index}")]

        [HttpDelete]
        public IHttpActionResult DeleteImage(int Id,int index)
        {
            var name = Id.ToString();
            var imageInDb = _context.Image.Where(g => g.ImageName == name).ToList();

           
            if (imageInDb == null)
                return NotFound();

            if (imageInDb.Count == 1)
            {
                _context.Image.Remove(imageInDb[0]);
            }
            else
            {
               
                 _context.Image.Remove(imageInDb[index]);
                
            }
           
            _context.SaveChanges();

            return Ok();
        }

    }
}
