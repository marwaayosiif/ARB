using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ARB.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public int? MobilePhone { get; set; }

        public string Specialization { get; set; }

        public string Location { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<Patient> Patients { get; set; }

    }
}