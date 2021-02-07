﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ARB.Models;
namespace ARB.Dtos
{
    public class PatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Modality { get; set; }
        public string Status { get; set; }
        public ClinicalInfoDto ClinicalInfo { get; set; }
        public int ClinicalInfoId { get; set; }
        public GeneralInfo GeneralInfo { get; set; }
        public int GeneralInfoId { get; set; }
        public FinalAssessmentDto FinalAssessment { get; set; }
        public int FinalAssessmentId { get; set; }
    }
}