using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB.Models
{
    public class Report
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Byte[] TileImage { get; set; }
    }

}