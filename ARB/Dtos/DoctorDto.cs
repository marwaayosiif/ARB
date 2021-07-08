using ARB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB.Dtos
{
    public class DoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int? MobilePhone { get; set; }

        public string Specialization { get; set; }

        public string Location { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public List<Patient> Patients { get; set; }
    }
}