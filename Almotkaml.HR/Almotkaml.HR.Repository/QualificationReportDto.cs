
using Almotkaml.HR.Models;
using System;
using System.Collections.Generic;

namespace Almotkaml.HR.Repository
{
    public class QualificationReportDto

    {
        public int QualificationTypeId { get; set; }
        public int SpecialtyId { get; set; }
        public int SubSpecialtyId { get; set; }
        public int ExactSpecialtyId { get; set; }
        public string AquiredSpecialty { get; set; } // التخصص المكتسب
    }

   
}