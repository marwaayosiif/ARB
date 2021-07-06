using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB.Models
{
    public class MassSpecification
    {
        public int Id { get; set; }
        public String MassShape { get; set; }
        public MassMargin MassMargin { get; set; }
        public int MassMarginId { get; set; }
        public MassDensity MassDensity { get; set; }
        public int MassDensityId { get; set; }
        public string Laterality { get; set; }
        public Quadrant Quadrant { get; set; }
        public int QuadrantId { get; set; }
        public ClockFace ClockFace { get; set; }
        public int ClockFaceId { get; set; }
        public string Depth { get; set; }
        public string DistanceFromTheNipple { get; set; }

        // Navigation properties 
        public int ClinicalInfoId { get; set; }
/*        public ClinicalInfo clinicalInfo { get; set; }*/
    }
}