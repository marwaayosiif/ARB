using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ARB.Models;
namespace ARB.ViewModels
{
    public class PatientViewModel
    {
        public IEnumerable<Doctor> Doctors { get; set; }
        public IEnumerable<Patient> Patients { get; set; }
    }
}