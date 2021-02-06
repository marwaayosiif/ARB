﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ARB.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Patient> Patients { get; set; }
        public List<int> PatientsId { get; set; }

    }
}