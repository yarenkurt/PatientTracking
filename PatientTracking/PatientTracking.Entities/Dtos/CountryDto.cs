using PatientTracking.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientTracking.Entities.Dtos
{
   public class CountryDto:IBaseDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string CountryCode { get; set; }
    }
}
