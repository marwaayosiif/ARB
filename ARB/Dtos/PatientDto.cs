using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ARB.Models;
namespace ARB.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }

        public int ExamDataId { get; set; }
        public int DoctorId { get; set; }
        public int ClinicalInfoId { get; set; }
        public int GeneralInfoId { get; set; }
        public int FinalAssessmentId { get; set; }

        public FinalAssessment FinalAssessment { get; set; }
        public ClinicalInfo ClinicalInfo { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
    }
}