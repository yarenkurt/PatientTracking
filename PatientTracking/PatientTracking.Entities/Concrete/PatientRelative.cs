using PatientTracking.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientTracking.Entities.Concrete
{
    public class PatientRelative : IBaseEntity
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gsm { get; set; }
        public int RelativeDegreeId { get; set; }


        public Patient Patient { get; set; }
        public RelativeDegree RelativeDegree { get; set; }
    }
}
