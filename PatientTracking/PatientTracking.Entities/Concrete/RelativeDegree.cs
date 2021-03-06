using PatientTracking.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientTracking.Entities.Concrete
{
    public class RelativeDegree : IBaseEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
