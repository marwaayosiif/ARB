using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Patient Patient { get; set; }
        public List<int> PatientId { get; set; }

    }
}