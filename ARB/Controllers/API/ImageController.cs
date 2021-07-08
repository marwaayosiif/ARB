
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
    [RoutePrefix("api/Image")]
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

            var httpRequest = HttpContext.Current.Request;

            var postedFile = httpRequest.Files["Image"];
            
            imageName = new String(Path.GetFileNameWithoutExtension(postedFile.FileName).Take(100).ToArray()).Replace(" ", "-");

            var id = imageName.Split('_')[1];

            System.Diagnostics.Debug.WriteLine("id");

            System.Diagnostics.Debug.WriteLine(id);

            imageName = imageName + Path.GetExtension(postedFile.FileName);

            string path1 = @"G:\SBME\GP\GP\ARB\ARB\Images";

            string path2 = Path.Combine(path1, $"Patient{id}");

            Directory.CreateDirectory(path2);

            var filePath = HttpContext.Current.Server.MapPath($"~/Images/Patient{id}/" + imageName);

            postedFile.SaveAs(filePath);

            Image image = new Image()
            {
                ImageName = imageName,
                FILEPATHNAME = filePath,
                PatientId = 1
            };
            _context.Image.Add(image);
            _context.SaveChanges();

            return Request.CreateResponse(HttpStatusCode.Created);

        }
        [HttpGet]
        public IHttpActionResult GetImages(int id)
        {
            const string folderName = @"G:\SBME\GP\GP\ARB\ARB\Images";
            string[] files = { };
            try
            {
                 

                var Fullpath = Path.Combine(folderName, $"Patient{id}");


                files = Directory.GetFiles(Fullpath);


                System.Diagnostics.Debug.WriteLine(files);


            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

            return Ok(files);
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
