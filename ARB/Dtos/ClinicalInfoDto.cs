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
        public List<MassSpecification> MassSpecifications { get; set; }
        public String BreastCompostion { get; set; }
        public int NumOfMass { get; set; }

        public Asymmetries Asymmetries { get; set; }
        public int AsymmetriesId { get; set; }
        public Features Features { get; set; }
        public int FeatureId { get; set; }

        public ClacificationTypicallyBenign TypicallyBenign { get; set; }
        public int TypicallyBenignId { get; set; }
        public ClacificationSuspiciousMorphology SuspiciousMorphology { get; set; }

        public int SuspiciousMorphologyId { get; set; }
        public ClacificationDistribution Distribution { get; set; }
        public int DistributionId { get; set; }

        public string Depth { get; set; }
        public string DistanceFromTheNipple { get; set; }
    }
}