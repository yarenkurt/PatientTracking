﻿using PatientTracking.Core.Signatures;

namespace PatientTracking.Entities.Concrete
{
    public class Department:IBaseEntity
    {
        public int Id { get; set; }
        public int HospitalId { get; set; }
        public string Description { get; set; }
        public Hospital Hospital { get; set; }

    }
}
