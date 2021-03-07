using PatientTracking.Core.Signatures;
using System;

namespace PatientTracking.Entities.Concrete
{
    public class PatientAnswer:IBaseEntity
    {
        
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int QuestionPoolId { get; set; }
        public decimal Point { get; set; }
        public DateTime CreatedAt { get; set; }

        public Patient Patient { get; set; }
        public QuestionPool QuestionPool { get; set; }
    }
}
