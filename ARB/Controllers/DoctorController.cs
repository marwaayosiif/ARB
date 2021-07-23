using ARB.Models;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using Microsoft.AspNet.Identity.Owin;
using System.Text;
using System;

namespace ARB.Controllers
{
    public class DoctorController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationUserManager _userManager;
        public DoctorController()
        {
            _context = new ApplicationDbContext();

        }
        public DoctorController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
       
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }



        // GET: Doctor
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register_Doctor(Doctor model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Name, Email = model.Email };

                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                     var doctor = new Doctor { Name = model.Name, Email = model.Email, Password = model.Password };
                    _context.Doctors.Add(doctor);
                    _context.SaveChanges();
                    Send_Email(model.Email,model.Password);
                    return RedirectToAction("Index", "Doctor");
                
                }
             
                
            }

            // If we got this far, something failed, redisplay form
  
            return RedirectToAction("Index", "Doctor");
        }

        public void Send_Email(string Email, string Password)
        {
            System.Diagnostics.Debug.WriteLine("Email" + Email);
            System.Diagnostics.Debug.WriteLine("Password" + Password);


            string to = Email; //To address    
            string from = "salmahamza108@gmail.com"; //From address    
            
            MailMessage message = new MailMessage(from, to);

            string mailbody = "your Email"+ Email + "and Password is" + Password ;
            message.Subject = "Congratulation";
            message.Body = mailbody;
            message.BodyEncoding = Encoding.UTF8;
            message.IsBodyHtml = true;
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587); //Gmail smtp   
            
            System.Net.NetworkCredential basicCredential1 = new
            System.Net.NetworkCredential(from, "");
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = basicCredential1;
            try
            {
                System.Diagnostics.Debug.WriteLine("DONE:"+message);
                client.Send(message);
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
                throw ex;
            }

        }

    }
}