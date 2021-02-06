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
        public List<PatientDto> Patient { get; set; }
        public List<int> PatientId { get; set; }
    }
}