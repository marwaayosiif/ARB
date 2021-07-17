using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ARB.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string PatientId { get; set; }
        public string ImageName { get; set; }
        public int? FileLength { get; set; }

        public Byte[] data { get; set;}


    }
}
