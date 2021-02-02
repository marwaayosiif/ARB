using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ARB.Models;

namespace ARB.ViewModels
{
    public class FinalAssessmentViewModel
    {
        public FinalAssessment FinalAssessment { get; set; }
        public IEnumerable<BiRads> BiRads { get; set; }
        public IEnumerable<Recommendation> Recommendations { get; set; }
    }
}