using PatientTracking.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientTracking.Entities.Dtos
{
   public class PatientDto : IBaseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gsm { get; set; }
        public string Email { get; set; }
    }
}
