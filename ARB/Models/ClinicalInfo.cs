using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARB.Models
{
    public class ClinicalInfo
    {
        public int Id { get; set; }
        
        public String BreastCompostion { get; set; }
        public int NumOfMass { get; set; }
        public List<MassSpecification> MassSpecifications { get; set; }

        public Asymmetries Asymmetries { get; set; }
        [Display (Name = "Asymmetries")]
        public int AsymmetriesId { get; set; }
        public Features Features { get; set; }
        [ForeignKey("Features")]
        public int FeatureId { get; set; }

        public ClacificationTypicallyBenign TypicallyBenign { get; set; }
        [Display(Name = "Typically Benign")]
        public int TypicallyBenignId { get; set; }
        public ClacificationSuspiciousMorphology SuspiciousMorphology { get; set; }

        [Display(Name = "Suspicious Morphology ")]
        public int SuspiciousMorphologyId { get; set; }
        public ClacificationDistribution Distribution { get; set; }
        [Display(Name = "Distribution")]
        public int DistributionId { get; set; }

        /* public String MassShape { get; set; }

        public MassMargin MassMargin { get; set; }
         [Display(Name = "Mass Margin")]

         public int MassMarginId { get; set; }
         public MassDensity MassDensity { get; set; }
         [Display(Name = "Mass Density")]
         public int MassDensityId { get; set; }*/

        /*        public string Laterality { get; set; }
                public Quadrant Quadrant { get; set; }
                [Display(Name = "Quadrant")]
                public int QuadrantId { get; set; }

                public ClockFace ClockFace { get; set; }
                [Display(Name = "Clock Face")]
                public int ClockFaceId { get; set; }

                public string Depth { get; set; }
                public string DistanceFromTheNipple { get; set; }*/
    }

   
}