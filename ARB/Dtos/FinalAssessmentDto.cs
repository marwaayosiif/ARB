using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB.Dtos
{
    public class FinalAssessmentDto
    {
        public int Id { get; set; }
        public BiRadsDto BiRads { get; set; }
        public int BiRadsId { get; set; }
        public RecommendationDto Recommendation { get; set; }
        public int RecommendationId { get; set; }
        public string RecommendationText { get; set; }
        public string Conc { get; set; }    
    }
}