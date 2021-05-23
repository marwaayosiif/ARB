using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB.Dtos
{
    public class ExamDataDto
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public string EmailAddress { get; set; }
        public string MobileNumber { get; set; }
        public string PatientID { get; set; }
        public string Address { get; set; }
        public string Modailty { get; set; }
        public string ReferringDoctor { get; set; }
        public DateTime StudyDate { get; set; }
        public string LastOperation { get; set; }
    }
}