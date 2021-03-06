using PatientTracking.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientTracking.Entities.Concrete
{
    public class Appointment:IBaseEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }


        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }

    }
}
