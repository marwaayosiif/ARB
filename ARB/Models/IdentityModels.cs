using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using ARB.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ARB.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ClinicalInfo> ClinicalInfos { get; set; }
        public DbSet<Asymmetries> Asymmetries { get; set; }
        public DbSet<Features> Features { get; set; }
        public DbSet<Quadrant> Quadrants { get; set; }
        public DbSet<MassMargin> MassMargin { get; set; }
        public DbSet<MassDensity> MassDensity { get; set; }
        public DbSet<ClacificationTypicallyBenign> ClacificationTypicallyBenign { get; set; }
        public DbSet<ClacificationSuspiciousMorphology> ClacificationSuspiciousMorphology { get; set; }
        public DbSet<ClacificationDistribution> ClacificationDistribution { get; set; }
        public DbSet<ClockFace> ClockFaces { get; set; }
        public DbSet<GeneralInfo> GeneralInfos { get; set; }
        public DbSet<FinalAssessment> FinalAssessments { get; set; }
        public DbSet<BiRads> BiRads { get; set; }
        public DbSet<Recommendation> Recommendations { get; set; }
    
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}