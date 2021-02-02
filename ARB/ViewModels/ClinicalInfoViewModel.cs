using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ARB.Models;
namespace ARB.ViewModels
{
    public class ClinicalInfoViewModel 
    { 
    
        public ClinicalInfo ClinicalInfo { get; set; }

        public IEnumerable<Asymmetries> Asymmetries { get; set; }
     
        public IEnumerable<MassMargin> MassMargin { get; set; }
        public IEnumerable<MassDensity> MassDensity { get; set; }
        public IEnumerable<ClacificationTypicallyBenign> ClacificationTypicallyBenign { get; set; }
        public IEnumerable<ClacificationSuspiciousMorphology> ClacificationSuspiciousMorphology { get; set; }
        public IEnumerable<ClacificationDistribution> ClacificationDistribution { get; set; }
        public IEnumerable<Quadrant> Quadrant { get; set; }
        public IEnumerable<ClockFace> ClockFace { get; set; }


       

    }
}