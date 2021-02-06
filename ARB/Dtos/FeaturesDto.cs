using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB.Dtos
{
    public class FeaturesDto
    {
        public int Id { get; set; }
        public bool SkinRetraction { get; set; }
        public bool NippleRetraction { get; set; }
        public bool SkinThickening { get; set; }
        public bool ArchitecturalDistortion { get; set; }
        public bool IntramammaryLymphNode { get; set; }
        public bool SkinLesion { get; set; }
        public bool SolitaryDilatedDuct { get; set; }
        public bool TrabecularThickening { get; set; }
        public bool AxillaryAdenopathy { get; set; }
    }
}