using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ARB.Models;
namespace ARB.Dtos
{
    public class ClinicalInfoDto
    {
        public int Id { get; set; }
        public String BreastCompostion { get; set; }
        public int NumOfMass { get; set; }
        public Asymmetries Asymmetries { get; set; }
        public int AsyId { get; set; }
        public FeaturesDto Features { get; set; }
        public int FeaturesId { get; set; }
        public String MassShape { get; set; }

        public MassMargin MassMargin { get; set; }
        public int MassMarginId { get; set; }
        public MassDensity MassDensity { get; set; }
        public int MassDensityId { get; set; }
        public ClacificationTypicallyBenign TypicallyBenign { get; set; }
        public int TypicallyBenignId { get; set; }
        public ClacificationSuspiciousMorphology SuspiciousMorphology { get; set; }
        public int SuspiciousMorphologyId { get; set; }
        public ClacificationDistribution Distribution { get; set; }
        public int DistributionId { get; set; }
        public string Laterality { get; set; }
        public Quadrant Quadrant { get; set; }
        public int QuadrantId { get; set; }

        public ClockFace ClockFace { get; set; }
        public int ClockFaceId { get; set; }

        public string Depth { get; set; }
        public string DistanceFromTheNipple { get; set; }
    }
}