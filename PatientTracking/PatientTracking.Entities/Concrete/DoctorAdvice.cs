using PatientTracking.Core.Signatures;
using System;

namespace PatientTracking.Entities.Concrete
{
    public class DoctorAdvice : IBaseEntity
    {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ReadingTime { get; set; }

        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
