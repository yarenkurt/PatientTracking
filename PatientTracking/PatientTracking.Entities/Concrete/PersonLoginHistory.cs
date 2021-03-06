using PatientTracking.Core.Signatures;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientTracking.Entities.Concrete
{
    public class PersonLoginHistory : IBaseEntity
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public string IpAddress { get; set; }
        public bool IsSuccess { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }

        public Person Person { get; set; }
    }
}
