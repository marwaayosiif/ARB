using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB.Models
{
    public class FinalAssessment
    {
        public int Id { get; set; }
        public BiRads BiRads { get; set; }
        public int BiRadsId { get; set; }
        public Recommendation Recommendation { get; set; }
        public int RecommendationId { get; set; }
        public string RecommendationText { get; set; }
        public string Conc { get; set; }
    }
}