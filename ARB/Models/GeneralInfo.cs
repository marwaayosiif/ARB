﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB.Models
{
    public class GeneralInfo
    {
        public int Id { get; set; }
        public DateTime? ExamDate { get; set; }
        public string ExamReason { get; set; }
        public string Complain { get; set; }
        public bool HadAMammogram { get; set; }
        public string WhenHadAMammogram { get; set; }
        public string WhereHadAMammogram { get; set; }
        public string HistoryOfMammogram { get; set; }
        public bool PersonalHistoryOfBreastCancer { get; set; }
        public bool Mother { get; set; }
        public int MotherAge { get; set; }
        public bool Sister { get; set; }
        public int SisterAge { get; set; }
        public bool Daughter { get; set; }
        public int DaughterAge { get; set; }
        public bool Grandmother { get; set; }
        public int GrandmotherAge { get; set; }
        public bool Aunt { get; set; }
        public int AuntAge { get; set; }
        public bool Cousin { get; set; }
        public int CousinAge { get; set; }
        public bool TakingHormones { get; set; }
        public string HowlongTakingHormones { get; set; }
        //Pergnancy 
        

    }
}